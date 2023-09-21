using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Entities
{
    public class CheckDTO
    {
        public int CheckId { get; set; }
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }
        public virtual CustomerDTO Customer { get; set; }

        public int SellerId { get; set; }
        public virtual SellerDTO Seller { get; set; }

        public virtual ICollection<SellDTO> Sells { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"#{CheckId} from {Created.ToString("dd.MM.yy hh:mm.ss")}";
        }
    }
}
