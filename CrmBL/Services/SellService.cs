using AutoMapper;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
namespace ShopCRM.BLL.Services
{
    public class SellService : ISellService
    {
        IContextUnitOfWork db;
        IMapper mapper;

        public SellService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SellDTO>> GetAllAsync()
        {
            var sells = await db.Sells.GetAllAsync();

            var result = new List<SellDTO>();

            foreach (var sell in sells)
            {
                result.Add(mapper.Map<SellDTO>(sell));
            }

            return result;
        }

        public async Task<SellDTO?> GetAsync(int id)
        {
            var sell = await db.Sells.GetAsync(id);

            var result = mapper.Map<SellDTO>(sell);

            return result;
        }

        public async Task<SellDTO?> CreateAsync(SellDTO item)
        {
            var newsell = mapper.Map<Sell>(item);

            var result = await db.Sells.CreateAsync(newsell);
            await db.Save();

            return mapper.Map<SellDTO>(result);
        }

        public async Task UpdateAsync(SellDTO item)
        {
            var updateSell = mapper.Map<Sell>(item);

            await db.Sells.UpdateAsync(updateSell);
            await db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Sells.DeleteAsync(id);
            await db.Save();
        }
    }
}
