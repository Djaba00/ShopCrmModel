using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using ShopCRM.Models;

namespace ShopCRM.Helpers
{
    public class Generator
    {
        Random rnd = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller> { };

        public List<Customer> CreateNewCustomers(int count)
        {
            var result = new List<Customer>();

            for(int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText(),
                };
                Customers.Add(customer);
                result.Add(customer); 
            }

            return result;
        }

        public List<Seller> CreateNewSellers(int count)
        {
            var result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Customers.Count,
                    Name = GetRandomText(),
                };
                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> CreateNewProducts(int count)
        {
            var result = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Customers.Count,
                    Name = GetRandomText(),
                    Price = rnd.Next(50, 10000),
                    Count = rnd.Next(1, 200)
                };
                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        public List<Product> GetRandomProduct(int min, int max)
        {
            var result = new List<Product>();

            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return result;
        }

        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
}
