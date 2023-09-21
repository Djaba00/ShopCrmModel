﻿namespace ShopCRM.DAL.Entities
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<SellDTO> Sells { get; set; }

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
            if (obj is ProductDTO product)
            {
                return ProductId.Equals(product.ProductId);
            }

            return false;
        }
    }
}