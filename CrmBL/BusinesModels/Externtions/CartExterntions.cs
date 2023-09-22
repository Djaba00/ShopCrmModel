//using ShopCRM.DAL.Entities;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace ShopCRM.BLL.BusinesModels.Externtions
//{
//    public static class CartExterntions
//    {
//        public static void Add(this Cart cart, ProductDTO product)
//        {
//            if (cart.Products.TryGetValue(product, out int count))
//            {
//                cart.Products[product] = ++count;
//            }
//            else
//            {
//                cart.Products.Add(product, 1);
//            }
//        }

//        public static IEnumerator GetEnumerator(this Cart cart)
//        {
//            foreach (var product in cart.Products.Keys)
//            {
//                for (int i = 0; i < cart.Products[product]; i++)
//                {
//                    yield return product;
//                }
//            }
//        }

//        public static List<ProductDTO> GetAll(this Cart cart)
//        {
//            var result = new List<ProductDTO>();

//            foreach (ProductDTO item in cart)
//            {
//                result.Add(item);
//            }
//            return result;
//        }

//        public static decimal GetPrice(this Cart cart)
//        {
//            return GetAll(cart).Sum(c => c.Price);
//        }
//    }
//}
