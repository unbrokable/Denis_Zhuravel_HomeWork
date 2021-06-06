using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Models
{
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal? Weight { get; set; }

        public override string ToString()
        {
            return $"Id: {ProductID} Name: {Name} Color: {Color?.ToString()??"Null"} Weight: { Weight?.ToString()??"Null"}";
        }
    }
}
