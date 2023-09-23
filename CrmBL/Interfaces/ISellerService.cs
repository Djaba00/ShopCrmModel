using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerDTO>> GetAllAsync();
        Task<SellerDTO?> GetAsync(int id);
        Task<SellerDTO?> CreateAsync(SellerDTO item);
        Task UpdateAsync(SellerDTO item);
        Task DeleteAsync(int id);
    }
}
