using ShopCRM.Helpers;
using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.ComputerModel
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random rnd = new Random();
        bool isWorking = false;
        List<Task> Tasks = new List<Task>();
        CancellationTokenSource CancellationTokenSource;
        CancellationToken CancellationToken;

        public List<CashDeskDTO> CashDesks { get; set; } = new List<CashDeskDTO>();
        public List<CartDTO> Carts { get; set; } = new List<CartDTO>();
        public List<CheckDTO> Checks { get; set; } = new List<CheckDTO>();
        public List<SellDTO> Sells { get; set; } = new List<SellDTO>();
        public Queue<SellerDTO> Sellers { get; set; } = new Queue<SellerDTO>();

        public int CustomerSpeed { get; set; } = 1000;
        public int CashDeskSpeed { get; set; } = 1000;

        public ShopComputerModel()
        {
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;

            var sellers = Generator.CreateNewSellers(20);
            var products = Generator.CreateNewProducts(1000);
            var customers = Generator.CreateNewCustomers(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDeskDTO(CashDesks.Count, Sellers.Dequeue(), null));
            }
            
        }

        public void Start()
        {
            Tasks.Add(new Task(() => CreateCarts(10, CancellationToken)));
            Tasks.AddRange(CashDesks.Select(c => new Task(() => CashDeskWork(c, CancellationToken))));

            foreach(Task task in Tasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }

        private void CashDeskWork(CashDeskDTO cashDesk, CancellationToken ct)
        {
            
            while(!ct.IsCancellationRequested
                )
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(CashDeskSpeed);
                }
            }
        }

        private void CreateCarts(int customersCount, CancellationToken ct)
        {
            while(!ct.IsCancellationRequested)
            {
                var customers = Generator.CreateNewCustomers(10);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    
                    foreach(var product in Generator.GetRandomProduct(10, 30))
                    {
                        cart.Add(product);
                    }

                    var cash = CashDesks[rnd.Next(CashDesks.Count)];
                    cash.Enqueue(cart);                    
                }
                Thread.Sleep(CustomerSpeed);
            }
        }
    }
}
