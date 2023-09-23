using Microsoft.EntityFrameworkCore;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.DAL.Repositories
{
    public  class CheckRepository : IRepository<Check>
    {
        CrmContext db;

        public CheckRepository()
        {
            db = new CrmContext();
        }

        public async Task<IEnumerable<Check>> GetAllAsync()
        {
            return await db.Checks.AsNoTracking().AsNoTracking().ToListAsync();
        }

        public async Task<Check?> GetAsync(int id)
        {
            return await db.Checks.AsNoTracking().FirstOrDefaultAsync(c => c.CheckId == id);
        }

        public async Task UpdateAsync(Check item)
        {
            var check = await GetAsync(item.CheckId);

            db.Checks.Entry(check).State = EntityState.Detached;

            check.Created = item.Created;
            check.Price = item.Price;

            db.Checks.Update(check);

            await db.SaveChangesAsync();
        }

        public async Task<Check?> CreateAsync(Check item)
        {
            var result = await db.Checks.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Checks.FirstOrDefaultAsync(c => c.CheckId == id);
            db.Checks.Entry(entryItem).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}
