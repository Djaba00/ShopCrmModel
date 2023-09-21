using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Entities
{
    public class SellDTO
    {
        public int SellId { get; set; }

        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }

        public int CheckId { get; set; }
        public virtual CheckDTO Check { get; set; }
    }
}
