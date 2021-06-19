using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Products
    {
        public int Product_Id { get; set; }
        public int? Merchant_Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
