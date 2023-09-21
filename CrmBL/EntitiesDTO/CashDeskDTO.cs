using ShopCRM.DAL.ApplicationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ShopCRM.DAL.Entities
{
    public class CashDeskDTO
    {
        CrmContext db = new CrmContext();

        public int Number { get; set; }
        public SellerDTO Seller { get; set; }
        public Queue<CartDTO> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public int Count => Queue.Count;

        public event EventHandler<CheckDTO> CheckClosed;

        public CashDeskDTO(int number, SellerDTO seller, CrmContext db)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<CartDTO>();
            IsModel = true;
            MaxQueueLenght = 100;
            this.db = db ?? new CrmContext();
        }

        public void Enqueue(CartDTO cart)
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

        public decimal Dequeue()
        {
            decimal summary = 0;
            if(Queue.Count == 0)
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
                    db.Checks.Add(check);
                    db.SaveChanges();
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
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        summary += product.Price;
                    }  
                }

                check.Price = summary;

                if (!IsModel)
                {
                    db.SaveChanges();
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
