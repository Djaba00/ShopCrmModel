using AutoMapper;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class SellerService : ISellerService
    {
        IContextUnitOfWork db;
        IMapper mapper;

        public SellerService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
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

        public async Task<SellerDTO?> CreateAsync(SellerDTO item)
        {
            var newseller = mapper.Map<Seller>(item);

            var result = await db.Sellers.CreateAsync(newseller);
            await db.Save();

            return mapper.Map<SellerDTO>(newseller);
        }

        public async Task UpdateAsync(SellerDTO item)
        {
            var updateSeller = mapper.Map<Seller>(item);

            await db.Sellers.UpdateAsync(updateSeller);
            await db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Sellers.DeleteAsync(id);
            await db.Save();
        }
    }
}
