using CrmBL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Models
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random rnd = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = Generator.CreateNewSellers(20);
            var products = Generator.CreateNewProducts(1000);
            var customers = Generator.CreateNewCustomers(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = Generator.CreateNewCustomers(10);

            var carts = new Queue<Cart>();

            foreach (var customer in customers)
            {
                var cart = new Cart(customer);

                foreach (var product in Generator.GetRandomProduct(10, 30))
                {
                    cart.Add(product);
                }

                carts.Enqueue(cart);
            }

            while(carts.Count > 0)
            {
                var minQueue = CashDesks.Min(c => c.Count);
                var cash = CashDesks.FirstOrDefault(c => c.Count == minQueue);

                cash.Dequeue();
            }

            while(true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                var money = cash.Dequeue();
            }
        }
    }
}
