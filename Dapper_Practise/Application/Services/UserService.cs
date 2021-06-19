using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IHasher hasher;

        public UserService(IRepository repository, IHasher hasher)
        {
            this.repository = repository;
            this.hasher = hasher;
        }

        public void EncryptUserByEmail(string email)
        {
            var user = repository.Find<Users>(i => i.Email,email ) ?? throw new ArgumentException("Cant find this user");
            var merchant = repository.Find<Merchants>(i => i.User_Id , user.User_Id);
            var orders = repository.GetBy<Orders>(i => i.User_Id,user.User_Id);

            user = hasher.HashObject<Users>(user);

            if (merchant != null)
            {
                merchant = hasher.HashObject<Merchants>(merchant);
                repository.Update(merchant);
            }

            foreach (var order in orders)
            {
                dynamic orderJson = JsonConvert.DeserializeObject(order.OrderJson);
                orderJson.Order.User.FullName = hasher.Hash(orderJson.Order.User.FullName.ToString());
                orderJson.Order.User.Email = hasher.Hash(orderJson.Order.User.Email.ToString());
                if (merchant != null)
                {
                    foreach (var product in orderJson.Order.Products)
                    {
                        product.Merchant.Name = hasher.Hash(product.Merchant.Name.ToString());
                    }
                }
                order.OrderJson = JsonConvert.SerializeObject(orderJson);
            }

            repository.Update(user);
            if(orders != null)
            {
                repository.Update(orders);
            }
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = repository.Find<Users>(i => i.Email, email )??throw new ArgumentException("Cant find this user");
            var merchant = repository.Find<Merchants>(i => i.User_Id ,user.User_Id);
            var orders = repository.GetBy<Orders>(i => i.User_Id, user.User_Id).ToList();

            return new UserDTO()
            {
                Email = user.Email,
                UserId = user.User_Id,
                Gender = user.Gender,
                FullName = user.FullName,
                Orders = orders.Select(i => new OrderDTO { OrderJson = i.OrderJson, Order_Id = i.Order_Id }).ToList(),
                Merchant = (merchant != null) ? new MerchantDTO { Merchant_Id = merchant.Merchant_Id, Name = merchant.Name } : null
            };
        }

        public void CreateData()
        {
            if (repository.Find<Users>(i => i.User_Id, 1) != null)
            {
                return;
            }
            repository.Add<Users>(new Users
            {
                FullName = "Denis",
                Email = "d@gmail.com",
                CreatedAt = DateTime.Now,
                Gender = "male"
            });

            repository.Add<Merchants>(new Merchants
            {
               User_Id = 1,
               Name = "SALERdenis",
               CreatedAt = DateTime.Now
            });

            repository.Add<Orders>(new Orders
            {
                User_Id = 1,
                Status = "ready",
                OrderJson = "{\"Order\":{\"OrderId\":1," +
                "\"User\":{\"FullName\": \"Denis\",\"Email\":\"d@gmail.com\",}," +
                "\"Products\":[" +
                "{\"Merchant\":{\"Name\": \"Saler\",},\"Name\":\"Saler\",\"Price\":\"\",}" +
                "],}}",
                CreatedAt = DateTime.Now
            });
        }
    }
}
