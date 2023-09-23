using ShopCRM.BLL.DTO;

namespace ShopCRM.BLL.Interfaces
{
    public interface ICheckService
    {
        Task<IEnumerable<CheckDTO>> GetAllAsync();
        Task<CheckDTO?> GetAsync(int id);
        Task<CheckDTO?> CreateAsync(CheckDTO item);
        Task UpdateAsync(CheckDTO item);
        Task DeleteAsync(int id);
    }
}
