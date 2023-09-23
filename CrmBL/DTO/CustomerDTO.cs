using System.Collections.Generic;

namespace ShopCRM.BLL.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CheckDTO> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
