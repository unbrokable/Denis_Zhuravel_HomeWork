using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Models
{
    class Custumer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {CustomerID} Name: {Name}";
        }
    }
}
