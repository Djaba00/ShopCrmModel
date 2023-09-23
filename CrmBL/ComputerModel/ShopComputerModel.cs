using ShopCRM.Helpers;
using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCRM.BLL.BusinesModels;
using AutoMapper;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;

namespace ShopCRM.BLL.ComputerModel
{
    public class ShopComputerModel
    {
        IMapper mapper;
        Generator Generator;
        Random rnd = new Random();
        bool isWorking = false;
        List<Task> Tasks = new List<Task>();
        CancellationTokenSource CancellationTokenSource;
        CancellationToken CancellationToken;

        public List<CashDeskService> CashDesks { get; set; } = new List<CashDeskService>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<CheckDTO> Checks { get; set; } = new List<CheckDTO>();
        public List<SellDTO> Sells { get; set; } = new List<SellDTO>();
        public Queue<ISellerService> Sellers { get; set; } = new Queue<ISellerService>();

        public int CustomerSpeed { get; set; } = 1000;
        public int CashDeskSpeed { get; set; } = 1000;

        public ShopComputerModel(IMapper mapper)
        {
            this.mapper = mapper;
            Generator = new Generator(mapper);
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
                CashDesks.Add(new CashDeskService(Sellers.Dequeue(), null, mapper, CashDesks.Count));
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

        private void CashDeskWork(CashDeskService cashDesk, CancellationToken ct)
        {
            
            while(!ct.IsCancellationRequested
                )
            {
                if (cashDesk.CashDesk.Count > 0)
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
