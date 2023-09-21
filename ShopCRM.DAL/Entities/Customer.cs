using System.Collections.Generic;

namespace ShopCRM.DAL.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Check> Checks { get; set; }
    }
}
