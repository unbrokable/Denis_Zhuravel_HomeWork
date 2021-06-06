using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Models
{
    class ProductInfo
    {
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }

        public override string ToString()
        {
            return $"Min: {Min} Max: {Max}";
        } 
    }
}
