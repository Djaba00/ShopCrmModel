using Microsoft.EntityFrameworkCore;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Repositories.Interfaces;

namespace ShopCRM.DAL.Repositories
{
    public  class CheckRepository : IRepository<Check>
    {
        CrmContext db;

        public CheckRepository(CrmContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Check>> GetAllAsync()
        {
            return await db.Checks.ToListAsync();
        }

        public async Task<Check?> GetAsync(int id)
        {
            return await db.Checks.FirstOrDefaultAsync(c => c.CheckId == id);
        }

        public async Task UpdateAsync(Check item)
        {
            db.Checks.Entry(item).State = EntityState.Modified;
        }

        public async Task CreateAsync(Check item)
        {
            await db.Checks.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Checks.FirstOrDefaultAsync(c => c.CheckId == id);
            db.Checks.Entry(entryItem).State = EntityState.Deleted;
        }
    }
}
