using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_Now
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };
            FirstUser(customers);
            AvgBalance(customers);
            DateBetween(new DateTime(2016, 5, 17), new DateTime(2017, 12, 29), customers);
            FilterById(customers,12);
            FilterByName(customers, "an");
            FilterByMonth(customers);
            OrderByPropeties(customers, "Name", "ASC");
            PrintName(customers);
        }
        public static void FirstUser(List<Customer> customers)
        {
            var mindateTime = customers.Min(i => i.RegistrationDate);
            Console.WriteLine(customers.FirstOrDefault(i => i.RegistrationDate == mindateTime));
        }
        public static void AvgBalance(List<Customer> customers)
        {
            var avgBalance = customers.Average(i => i.Balance);
            Console.WriteLine($"Avg balance = {avgBalance}");
        }
        public static void FilterById(List<Customer> customers, int id)
        {
            var filterById = customers.Where(i => i.Id == id);
            Console.WriteLine("Filter by id");
            filterById.ToList().ForEach(i => Console.WriteLine(i));
        }
        public static void DateBetween(DateTime first , DateTime second , List<Customer> customers)
        {
            if(first > second)
            {
                DateTime date = first;
                first = second;
                second = date;
            }
            Console.WriteLine("Filter by Date");
            var filterCustumer = customers.Where(i => i.RegistrationDate >= first && i.RegistrationDate <= second);
            if(filterCustumer.Count()== 0)
            {
                Console.WriteLine("No result");
            }
            else
            {
                filterCustumer.ToList().ForEach(i => Console.WriteLine(i.ToString()) );
            }
        }
        public static void FilterByName(List<Customer> customers, string match)
        {
            Console.WriteLine("Filter by Name");
            var filterByName = customers.Where(i => i.Name.Contains(match, StringComparison.OrdinalIgnoreCase));
            filterByName.ToList().ForEach(i => Console.WriteLine(i));
        }
        public static void FilterByMonth(List<Customer> customers)
        {
            Console.WriteLine("Filter by Month");
            List<List<Customer>> groupCustumers = new List<List<Customer>>();
            for (int i = 1; i <= 12; i++)
            {
                var monthCustumer = customers.Where(item => item.RegistrationDate.Month == i).ToList();
                if (monthCustumer.Count != 0)
                {
                    groupCustumers.Add(monthCustumer);
                }
            }
            for (int i = 0; i < groupCustumers.Count; i++)
            {
                groupCustumers[i] = groupCustumers[i].OrderBy(o => o.Name).ToList();
                groupCustumers[i].ForEach(j => Console.WriteLine(j));
            }
        }
        public static void OrderByPropeties(List<Customer> customers, string property, string order)
        {
            Console.WriteLine("Order by properties");
            List<Customer> orderList = new List<Customer>();
            if (String.Equals(order, "ASC",StringComparison.OrdinalIgnoreCase))
            {
                 orderList = customers.OrderBy(i => i.GetType().GetProperty(property).GetValue(i) ).ToList();
            }
            else if (String.Equals(order, "DESC", StringComparison.OrdinalIgnoreCase))
            {
                orderList = customers.OrderByDescending(i => i.GetType().GetProperty(property).GetValue(i)).ToList();
            }
            orderList.ForEach(i => Console.WriteLine(i));
        }
        public static void PrintName(List<Customer> customers)
        {
            Console.WriteLine("Print Names");
            StringBuilder @string = new StringBuilder();
            customers.ForEach(i => @string.Append(i.Name).Append(","));
            Console.WriteLine(@string.ToString().Remove(@string.Length-1));

        }
        // definition of Customer:
        public class Customer
        {
            public long Id { get; set; }

            public string Name { get; set; }

            public DateTime RegistrationDate { get; set; }

            public double Balance { get; set; }

            public Customer(long id, string name, DateTime registrationDate, double balance)
            {
                this.Id = id;
                this.Name = name;
                this.RegistrationDate = registrationDate;
                this.Balance = balance;
            }
            public override string ToString()
            {
                return $"Id = {Id} Name = {Name} RegistrationDate = {RegistrationDate.ToShortDateString()} Balance = {Balance}";
            }
        }
    }
}