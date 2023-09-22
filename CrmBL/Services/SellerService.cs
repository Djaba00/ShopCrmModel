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
    public class SellerService : IEntityService<SellerDTO>
    {
        IContextUnitOfWork db;
        IMapper mapper;
        List<SellerDTO> SellersList;

        public SellerService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
            SellersList = db.Se
        }

        public async Task<IEnumerable<SellerDTO>> GetAllAsync()
        {
            var sellers = await db.Sellers.GetAllAsync();

            var result = new List<SellerDTO>();

            foreach (var seller in sellers)
            {
                result.Add(mapper.Map<SellerDTO>(seller));
            }

            return result;
        }

        public async Task<SellerDTO?> GetAsync(int id)
        {
            var seller = await db.Sellers.GetAsync(id);

            var result = mapper.Map<SellerDTO>(seller);

            return result;
        }

        public async Task CreateAsync(SellerDTO item)
        {
            var newseller = mapper.Map<Seller>(item);

            await db.Sellers.CreateAsync(newseller);
        }

        public async Task UpdateAsync(SellerDTO item)
        {
            var updateSeller = mapper.Map<Seller>(item);

            await db.Sellers.UpdateAsync(updateSeller);
        }

        public async Task DeleteAsync(int id)
        {
            await db.Sellers.DeleteAsync(id);
        }
    }
}
