using AutoMapper;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.ApplicationContext;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        IContextUnitOfWork db;
        IMapper mapper;
        CheckService CheckService;
        CustomerService CustomerService;
        ProductService ProductService;
        SellerService SellerService;
        SellService SellService;

        private bool disposed = false;

        public ServiceUnitOfWork(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEntityService<CheckDTO> ChecksDTO
        {
            get
            {
                if (CheckService == null)
                {
                    CheckService = new CheckService(db, mapper);
                }
                return CheckService;
            }
        }
        public IEntityService<CustomerDTO> CustomersDTO
        {
            get
            {
                if (CustomerService == null)
                {
                    CustomerService = new CustomerService(db, mapper);
                }
                return CustomerService;
            }
        }
        public IEntityService<ProductDTO> ProductsDTO
        {
            get
            {
                if (ProductService == null)
                {
                    ProductService = new ProductService(db, mapper);
                }
                return ProductService;
            }
        }
        public IEntityService<SellerDTO> SellersDTO
        {
            get
            {
                if (SellerService == null)
                {
                    SellerService = new SellerService(db, mapper);
                }
                return SellerService;
            }
        }
        public IEntityService<SellDTO> SellsDTO
        {
            get
            {
                if (SellService == null)
                {
                    SellService = new SellService(db, mapper);
                }
                return SellService;
            }
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
