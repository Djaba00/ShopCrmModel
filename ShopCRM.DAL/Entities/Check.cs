using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Entities
{
    public class Check
    {
        public int CheckId { get; set; }
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }
        public decimal Price { get; set; }
    }
}
