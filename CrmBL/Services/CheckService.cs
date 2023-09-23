using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class CheckService : ICheckService
    {
        IContextUnitOfWork db;
        IMapper mapper;
        public List<CheckDTO> Checks { get; set; }

        public CheckService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CheckDTO>> GetAllAsync()
        {
            var checks = await db.Checks.GetAllAsync();

            var result = new List<CheckDTO>();

            foreach (var check in checks)
            {
                result.Add(mapper.Map<CheckDTO>(check));
            }

            return result;
        }

        public async Task<CheckDTO?> GetAsync(int id)
        {
            var check = await db.Checks.GetAsync(id);

            var result = mapper.Map<CheckDTO>(check);

            return result;
        }

        public async Task<CheckDTO?> CreateAsync(CheckDTO item)
        {
            var newCheck = mapper.Map<Check>(item);

            var result = await db.Checks.CreateAsync(newCheck);
            await db.Save();

            return mapper.Map<CheckDTO>(result);
        }

        public async Task UpdateAsync(CheckDTO item)
        {
            var updateCheck = mapper.Map<Check>(item);

            await db.Checks.UpdateAsync(updateCheck);
            await db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Checks.DeleteAsync(id);
            await db.Save();
        }
    }
}
