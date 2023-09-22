﻿using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmWinForm.VIewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<SellViewModel> Sells { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price} руб.";
        }

        public override int GetHashCode()
        {
            return ProductId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ProductViewModel product)
            {
                return ProductId.Equals(product.ProductId);
            }

            return false;
        }
    }
}
