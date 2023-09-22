using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Entities
{
    public class SellerDTO
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CheckDTO> Checks { get; set; }
    }
}
