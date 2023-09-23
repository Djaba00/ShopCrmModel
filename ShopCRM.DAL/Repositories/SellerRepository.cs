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
    public class SellerRepository : IRepository<Seller>
    {
        CrmContext db;

        public SellerRepository(CrmContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Seller>> GetAllAsync()
        {
            return await db.Sellers.ToListAsync();
        }

        public async Task<Seller?> GetAsync(int id)
        {
            return await db.Sellers.FirstOrDefaultAsync(c => c.SellerId == id);
        }

        public async Task UpdateAsync(Seller item)
        {
            var seller = await GetAsync(item.SellerId);

            db.Sellers.Entry(seller).State = EntityState.Detached;

            seller.Name = item.Name;

            db.Sellers.Update(seller);
        }

        public async Task<Seller?> CreateAsync(Seller item)
        {
            var result = await db.Sellers.AddAsync(item);
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Sellers.FirstOrDefaultAsync(c => c.SellerId == id);
            db.Sellers.Entry(entryItem).State = EntityState.Deleted;
        }
    }
}
