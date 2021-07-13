using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class OrderItems
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
