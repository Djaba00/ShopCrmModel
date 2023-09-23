using AutoMapper;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using ShopCRM.DAL.Repositories;

namespace ShopCRM.BLL.BusinesModels
{
    public class CashDesk
    {
        

        public int Number { get; set; }
        public SellerDTO Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public int Count => Queue.Count;

        public CashDesk(int number, SellerDTO seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            MaxQueueLenght = 10; 
        }

        public override string ToString()
        {
            return $"Касса #{Number}";
        }
    }
}
