using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetAsync(int id);
        Task<ProductDTO?> CreateAsync(ProductDTO item);
        Task UpdateAsync(ProductDTO item);
        Task DeleteAsync(int id);
    }
}
