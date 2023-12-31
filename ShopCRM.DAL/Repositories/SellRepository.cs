﻿using Microsoft.EntityFrameworkCore;
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

        public SellRepository()
        {
            db = new CrmContext();
        }

        public async Task<IEnumerable<Sell>> GetAllAsync()
        {
            return await db.Sells.AsNoTracking().ToListAsync();
        }

        public async Task<Sell?> GetAsync(int id)
        {
            return await db.Sells.AsNoTracking().FirstOrDefaultAsync(c => c.SellId == id);
        }

        public async Task UpdateAsync(Sell item)
        {
            var sell = await GetAsync(item.SellId);

            db.Sells.Entry(sell).State = EntityState.Detached;

            sell.Product = item.Product;

            db.Sells.Update(sell);
            await db.SaveChangesAsync();
        }

        public async Task<Sell?> CreateAsync(Sell item)
        {
            var result = await db.Sells.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Sells.FirstOrDefaultAsync(c => c.SellId == id);
            db.Sells.Entry(entryItem).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}