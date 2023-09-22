using Microsoft.EntityFrameworkCore;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Repositories
{
    public class SellRepository : IRepository<Sell>
    {
        CrmContext db;

        public SellRepository(CrmContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Sell>> GetAllAsync()
        {
            return await db.Sells.ToListAsync();
        }

        public async Task<Sell?> GetAsync(int id)
        {
            return await db.Sells.FirstOrDefaultAsync(c => c.SellId == id);
        }

        public async Task UpdateAsync(Sell item)
        {
            db.Sells.Entry(item).State = EntityState.Modified;
        }

        public async Task CreateAsync(Sell item)
        {
            await db.Sells.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Sells.FirstOrDefaultAsync(c => c.SellId == id);
            db.Sells.Entry(entryItem).State = EntityState.Deleted;
        }
    }
}