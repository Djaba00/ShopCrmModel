using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.DAL.Interfaces
{
    public interface IServiceUnitOfWork : IDisposable
    {
        IEntityService<CheckDTO> ChecksDTO { get; }
        IEntityService<CustomerDTO> CustomersDTO { get; }
        IEntityService<ProductDTO> ProductsDTO { get; }
        IEntityService<SellDTO> SellsDTO { get; }
        IEntityService<SellerDTO> SellersDTO { get; }
    }
}
