using AutoMapper;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using ShopCRM.DAL.Repositories;

namespace ShopCRM.BLL.BusinesModels
{
    public class CashDesk
    {
        public IServiceUnitOfWork db { get; }
        public IMapper mapper { get; set; }

        public int Number { get; set; }
        public SellerDTO Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public int Count => Queue.Count;

        public event EventHandler<CheckDTO> CheckClosed;

        public CashDesk(int number, SellerDTO seller, IServiceUnitOfWork db, IMapper mapper)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            MaxQueueLenght = 100;
            this.mapper = mapper;
            this.db = db ?? new ServiceUnitOfWork(new ContextUnitOfWork(), mapper);
        }

        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public async Task<decimal> Dequeue()
        {
            decimal summary = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }

            var cart = Queue.Dequeue();

            if (cart != null)
            {
                var check = new CheckDTO()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    await db.ChecksDTO.CreateAsync(check);
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

                        if (!IsModel)
                        {
                            db.SellsDTO.CreateAsync(sell);
                        }

                        product.Count--;
                        summary += product.Price;
                    }
                }

                check.Price = summary;

                if (!IsModel)
                {
                    db.ChecksDTO.UpdateAsync(check);
                }

                CheckClosed?.Invoke(this, check);
            }

            return summary;
        }

        public override string ToString()
        {
            return $"Касса #{Number}";
        }
    }
}
