using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmWinForm.VIewModels
{
    public class SellViewModel
    {
        public int SellId { get; set; }

        public int ProductId { get; set; }
        public virtual ProductViewModel Product { get; set; }

        public int CheckId { get; set; }
        public virtual CheckViewModel Check { get; set; }
    }
}
