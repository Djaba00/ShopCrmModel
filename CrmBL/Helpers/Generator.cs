using AutoMapper;
using ShopCRM.BLL.BusinesModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.Helpers
{
    public class Generator
    {
        IMapper mapper;

        Random rnd = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<CustomerDTO> Customers { get; set; } = new List<CustomerDTO>();
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public List<SellerService> Sellers { get; set; } = new List<SellerService> { };

        public Generator(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<CustomerDTO> CreateNewCustomers(int count)
        {
            var result = new List<CustomerDTO>();

            for(int i = 0; i < count; i++)
            {
                var customer = new CustomerDTO()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText(),
                };
                Customers.Add(customer);
                result.Add(customer); 
            }

            return result;
        }

        public List<SellerService> CreateNewSellers(int count)
        {
            var result = new List<SellerService>();

            for (int i = 0; i < count; i++)
            {
                var seller = new SellerService(null, mapper);
                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<ProductDTO> CreateNewProducts(int count)
        {
            var result = new List<ProductDTO>();

            for (int i = 0; i < count; i++)
            {
                var product = new ProductDTO()
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

        public List<ProductDTO> GetRandomProduct(int min, int max)
        {
            var result = new List<ProductDTO>();

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
