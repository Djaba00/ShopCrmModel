using ShopCRM.BLL.BusinesModels;
using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Interfaces
{
    public interface ICashDeskService
    {
        public CashDesk CashDesk { get; set; }
        event EventHandler<CheckDTO> CheckClosed;
        void Enqueue(Cart cart);
        Task<decimal> Dequeue();
    }
}
