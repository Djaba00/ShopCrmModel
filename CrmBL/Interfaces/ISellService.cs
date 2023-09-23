using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Interfaces
{
    public interface ISellService
    {
        Task<IEnumerable<SellDTO>> GetAllAsync();
        Task<SellDTO?> GetAsync(int id);
        Task<SellDTO?> CreateAsync(SellDTO item);
        Task UpdateAsync(SellDTO item);
        Task DeleteAsync(int id);
    }
}
