using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO?> GetAsync(int id);
        Task<CustomerDTO?> CreateAsync(CustomerDTO item);
        Task UpdateAsync(CustomerDTO item);
        Task DeleteAsync(int id);
    }
}
