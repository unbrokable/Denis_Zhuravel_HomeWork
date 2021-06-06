using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using ADO.Models;
using Ninject;
using ADO.Interfaces;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-PG4V2V8; Database=AdventureWorksLT2019; Trusted_Connection=True";
            ServiceModul modul = new ServiceModul(connectionString);
            var kernel = new StandardKernel(modul);
            var sqlCommander = (ICommanderADO)kernel.Get(typeof(ICommanderADO));

            string sqlExpressionCategoriesSales = "Select c.ProductCategoryID, c.Name, sum(s.UnitPrice) as 'Sum' from SalesLT.ProductCategory c " +
                "join SalesLT.Product pr on pr.ProductCategoryID = c.ProductCategoryID " +
                "join SalesLT.SalesOrderDetail s on s.ProductID = pr.ProductID " +
                "group by c.ProductCategoryID, c.Name";

            Console.WriteLine("\nTask 7(1)\n");

            foreach (var item in sqlCommander.Execute<CategoriesSales>(sqlExpressionCategoriesSales, null))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nTask 7(2)\n");

            string sqlExpressionCustumersDiscounts = "Select  CustomerID, CONCAT(FirstName,' ', MiddleName,' ', LastName) as Name  from SalesLT.Customer " +
                "where CustomerID in ( " +
                "select distinct c.CustomerID from SalesLT.Customer c " +
                "join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID " +
                "join SalesLT.SalesOrderDetail sd on sd.SalesOrderID = sh.SalesOrderID " +
                "group by c.CustomerID " +
                "having  max(sd.UnitPriceDiscount * 100) > @discount )";

            foreach (var item in sqlCommander.Execute<Custumer>(sqlExpressionCustumersDiscounts, new Dictionary<string, object> { { "@discount",4 }}))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nTask 7(3)\n");

            string sqlExpressionCustumersPurchase = "select CustomerID, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) as Name from SalesLT.Customer " +
                "where CustomerID in( " +
                "select distinct c.CustomerID from SalesLT.Customer " +
                "c join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID " +
                "join SalesLT.SalesOrderDetail sd on sd.SalesOrderID = sh.SalesOrderID " +
                "group by c.CustomerID " +
                "having SUM(sd.UnitPrice) > @sum)";

            foreach (var item in sqlCommander.Execute<Custumer>(sqlExpressionCustumersPurchase, new Dictionary<string, object> { { "@sum", 15000 } }))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nTask 4(last)\n");

            string sqlExpressionProductsPage = "select ProductID, Name, Color, Weight from SalesLT.Product " +
                "order by Weight " +
                "OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";

            foreach (var item in sqlCommander.Execute<Product>(sqlExpressionProductsPage, new Dictionary<string, object> { { "@skip", 10 }, { "@take", 10 } }))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nTask 5(last)\n");

            string sqlExpressionProductsCategory = "select pr.ProductID, pr.Name, pr.ProductNumber as Number ,c2.Name as Category,c.Name as ParentCategory from  SalesLT.Product pr " +
                "join SalesLT.ProductCategory c on pr.ProductCategoryID = c.ProductCategoryID " +
                "join SalesLT.ProductCategory c2 on c2.ProductCategoryID = c.ParentProductCategoryID";

            foreach (var item in sqlCommander.Execute<ProductCategory>(sqlExpressionProductsCategory, null))
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\nTask 6(Min Max)\n");

            string sqlExpressionProductMinMaxWeight = "select Max(Weight) as Max, Min(Weight) as Min from SalesLT.Product";

            foreach (var item in sqlCommander.Execute<ProductInfo>(sqlExpressionProductMinMaxWeight, null))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
