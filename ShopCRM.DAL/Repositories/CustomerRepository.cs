﻿using Microsoft.EntityFrameworkCore;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        CrmContext db;

        public CustomerRepository(CrmContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<Customer?> GetAsync(int id)
        {
            return await db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task UpdateAsync(Customer item)
        {
            db.Customers.Entry(item).State = EntityState.Modified;
        }

        public async Task CreateAsync(Customer item)
        {
            await db.Customers.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            db.Customers.Entry(entryItem).State = EntityState.Deleted;
        }
    }
}