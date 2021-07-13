using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Orders
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderJson { get; set; }

    }
}
