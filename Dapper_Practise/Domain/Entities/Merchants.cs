using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Merchants
    {
        public int Merchant_Id { get; set; }
        public string Name { get; set; }
        public int? Country_Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? User_Id { get; set; }
    }
}
