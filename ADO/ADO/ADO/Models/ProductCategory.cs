using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Models
{
    class ProductCategory
    {
        public int ProductID { get; set; }
        public  string Name { get; set; }
        public string Number { get; set; }
        public string Category { get; set; }
        public string ParentCategory { get; set; }

        public override string ToString()
        {
            return $"Id: {ProductID} Name: {Name}  Number: {Number} Category: {Category} Parent Category {ParentCategory}";
        }
    }
}
