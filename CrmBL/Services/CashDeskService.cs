using AutoMapper;
using ShopCRM.BLL.BusinesModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using ShopCRM.DAL.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Services
{
    public class CashDeskService : ICashDeskService
    {
        public IContextUnitOfWork db { get; }
        public IMapper mapper { get; set; }
        public ISellerService sellerService { get; set; }

        public CashDesk CashDesk { get; set; }

        public event EventHandler<CheckDTO> CheckClosed;

        public CashDeskService(
            ISellerService sellerService, 
            IContextUnitOfWork db, 
            IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db ?? new ContextUnitOfWork();

            Random rnd = new Random();

            int number = rnd.Next(1, 10);

            CashDesk = new CashDesk(number, sellerService.GetAllAsync().Result.FirstOrDefault())
            {
                IsModel = false
            };
        }

        public void Enqueue(Cart cart)
        {
            if (CashDesk.Queue.Count <= CashDesk.MaxQueueLenght)
            {
                CashDesk.Queue.Enqueue(cart);
            }
            else
            {
                CashDesk.ExitCustomer++;
            }
        }

        public async Task<decimal> Dequeue()
        {
            decimal summary = 0;
            if (CashDesk.Queue.Count == 0)
            {
                return 0;
            }

            var cart = CashDesk.Queue.Dequeue();

            if (cart != null)
            {
                var check = new CheckDTO()
                {
                    SellerId = CashDesk.Seller.SellerId,
                    Seller = CashDesk.Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };

                if (!CashDesk.IsModel)
                {
                    await db.Checks.CreateAsync(mapper.Map<Check>(check));
                    await db.Save();
                }
                else
                {
                    check.CheckId = 0;
                }

                var sells = new List<SellDTO>();

                foreach (ProductDTO product in cart)
                {
                    if (product.Count > 0)
                    {
                        var sell = new SellDTO()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        sells.Add(sell);

                        if (!CashDesk.IsModel)
                        {
                            await db.Sells.CreateAsync(mapper.Map<Sell>(sell));
                            await db.Save();
                        }

                        product.Count--;
                        summary += product.Price;
                    }
                }

                check.Price = summary;

                if (!CashDesk.IsModel)
                {
                    await db.Checks.UpdateAsync(mapper.Map<Check>(check));
                    await db.Save();
                }

                CheckClosed?.Invoke(this, check);
            }

            return summary;
        }
    }
}
