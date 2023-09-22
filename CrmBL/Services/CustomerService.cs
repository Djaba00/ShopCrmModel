using AutoMapper;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class CustomerService : IEntityService<CustomerDTO>
    {
        IContextUnitOfWork db;
        IMapper mapper;

        public CustomerService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customers = await db.Customers.GetAllAsync();

            var result = new List<CustomerDTO>();

            foreach (var customer in customers)
            {
                result.Add(mapper.Map<CustomerDTO>(customer));
            }

            return result;
        }

        public async Task<CustomerDTO?> GetAsync(int id)
        {
            var check = await db.Customers.GetAsync(id);

            var result = mapper.Map<CustomerDTO>(check);

            return result;
        }

        public async Task CreateAsync(CustomerDTO item)
        {
            var newCustomer = mapper.Map<Customer>(item);

            await db.Customers.CreateAsync(newCustomer);
        }

        public async Task UpdateAsync(CustomerDTO item)
        {
            var updateCustomer = mapper.Map<Customer>(item);

            await db.Customers.UpdateAsync(updateCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            await db.Customers.DeleteAsync(id);
        }
    }
}
