using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Models
{
    class CategoriesSales
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"Id: {ProductCategoryID} Name: {Name} Saled products: {Sum} ";
        }
    }
}
