using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public ICollection <OrderDTO> Orders { get; set; }
        public MerchantDTO Merchant { get; set; }

        public override string ToString()
        {
            var @string = new StringBuilder()
                .AppendLine($"Id: {UserId} Name: {FullName} Email: {Email} Gender: {Gender}");
            if(Merchant != null)
            {
                @string.AppendLine($"Merchant: {Merchant.Merchant_Id} Name: {Merchant.Name}");
            }
            foreach (var item in Orders)
            {
                @string.AppendLine($"Order: {item.Order_Id}")
                    .AppendLine($"Json: {item.OrderJson}");
            }
            return @string.ToString();
        }
    }
}
