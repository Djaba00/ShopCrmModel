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
    public class ProductRepository : IRepository<Product>
    {
        CrmContext db;

        public ProductRepository(CrmContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await db.Products.FirstOrDefaultAsync(c => c.ProductId == id);
        }

        public async Task UpdateAsync(Product item)
        {
            db.Products.Entry(item).State = EntityState.Modified;
        }

        public async Task<Product?> CreateAsync(Product item)
        {
            var result = await db.Products.AddAsync(item);
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            db.Products.Entry(entryItem).State = EntityState.Deleted;
        }
    }
}
