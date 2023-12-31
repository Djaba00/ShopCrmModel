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
    public class CustomerRepository : IRepository<Customer>
    {
        CrmContext db;

        public CustomerRepository()
        {
            db = new CrmContext();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer?> GetAsync(int id)
        {
            return await db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task UpdateAsync(Customer item)
        {
            var customer = await GetAsync(item.CustomerId);

            db.Customers.Entry(customer).State = EntityState.Detached;

            customer.Name = item.Name;

            db.Customers.Update(customer);

            await db.SaveChangesAsync();
        }

        public async Task<Customer?> CreateAsync(Customer item)
        {
            var result = await db.Customers.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entryItem = await db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            db.Customers.Entry(entryItem).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }
    }
}
