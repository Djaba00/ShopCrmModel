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
    public class ContextUnitOfWork : IContextUnitOfWork
    {
        CrmContext db;
        CheckRepository CheckRepository;
        CustomerRepository CustomerRepository;
        ProductRepository ProductRepository;
        SellerRepository SellerRepository;
        SellRepository SellRepository;

        private bool disposed = false;

        public ContextUnitOfWork()
        {
            db = new CrmContext();
        }

        public IRepository<Check> Checks
        {
            get
            {
                if (CheckRepository == null)
                {
                    CheckRepository = new CheckRepository(db);
                }
                return CheckRepository;
            }
        }
        public IRepository<Customer> Customers
        {
            get
            {
                if (CustomerRepository == null)
                {
                    CustomerRepository = new CustomerRepository(db);
                }
                return CustomerRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (ProductRepository == null)
                {
                    ProductRepository = new ProductRepository(db);
                }
                return ProductRepository;
            }
        }
        public IRepository<Seller> Sellers
        {
            get
            {
                if (SellerRepository == null)
                {
                    SellerRepository = new SellerRepository(db);
                }
                return SellerRepository;
            }
        }
        public IRepository<Sell> Sells
        {
            get
            {
                if (SellRepository == null)
                {
                    SellRepository = new SellRepository(db);
                }
                return SellRepository;
            }
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
