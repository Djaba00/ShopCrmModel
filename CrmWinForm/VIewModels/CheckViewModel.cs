using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmWinForm.VIewModels
{
    public class CheckViewModel
    {
        public int CheckId { get; set; }
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }
        public virtual CustomerViewModel Customer { get; set; }

        public int SellerId { get; set; }
        public virtual SellerViewModel Seller { get; set; }

        public virtual ICollection<SellViewModel> Sells { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"#{CheckId} from {Created.ToString("dd.MM.yy hh:mm.ss")}";
        }
    }
}
