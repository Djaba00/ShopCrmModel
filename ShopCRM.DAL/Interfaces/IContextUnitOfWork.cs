using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Interfaces
{
    public interface IContextUnitOfWork : IDisposable
    {
        IRepository<Check> Checks { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Product> Products { get; }
        IRepository<Sell> Sells { get; }
        IRepository<Seller> Sellers { get; }

        Task Save();
    }
}
