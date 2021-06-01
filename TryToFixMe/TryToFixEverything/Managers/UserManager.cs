using BLL.Abstractions.Interfaces;
using BLL.DTOs;
using ConsoleApp8.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class UserManager:IUserManager
    {
        IUserService service;
        public UserManager(IUserService service)
        {
            this.service = service;
        }

        public void ShowRecords()
        {
            List<UserDTO> records = service.LoadRecords<UserDTO>();
            foreach (var item in records)
            {
                Console.WriteLine($"Matching Record, got name={item.FirstName}, lastname={item.LastName}, age={item.TotalPoints}");
            }
        }

    }
}
