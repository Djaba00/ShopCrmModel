using AutoMapper;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Services
{
    public class SellService : IEntityService<SellDTO>
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

        public async Task CreateAsync(SellDTO item)
        {
            var newsell = mapper.Map<Sell>(item);

            await db.Sells.CreateAsync(newsell);
        }

        public async Task UpdateAsync(SellDTO item)
        {
            var updateSell = mapper.Map<Sell>(item);

            await db.Sells.UpdateAsync(updateSell);
        }

        public async Task DeleteAsync(int id)
        {
            await db.Sells.DeleteAsync(id);
        }
    }
}
