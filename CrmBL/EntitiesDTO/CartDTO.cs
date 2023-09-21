﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Entities
{
    public class CartDTO : IEnumerable
    {
        public CustomerDTO Customer { get; set; }
        public Dictionary<ProductDTO, int> Products { get; private set; }
        public decimal Price => GetAll().Sum(p => p.Price);

        public CartDTO(CustomerDTO customer)
        {
            Customer = customer;
            Products = new Dictionary<ProductDTO, int>();
        }

        public void Add(ProductDTO product)
        {
            if (Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for(int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }

        public List<ProductDTO> GetAll()
        {
            var result = new List<ProductDTO>();

            foreach (ProductDTO item in this)
            {
                result.Add(item);
            }
            return result;
        }
    }
}