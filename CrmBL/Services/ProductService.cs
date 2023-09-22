using AutoMapper;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class ProductService : IEntityService<ProductDTO>
    {
        IContextUnitOfWork db;
        IMapper mapper;

        public ProductService(IContextUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await db.Products.GetAllAsync();

            var result = new List<ProductDTO>();

            foreach (var product in products)
            {
                result.Add(mapper.Map<ProductDTO>(product));
            }

            return result;
        }

        public async Task<ProductDTO?> GetAsync(int id)
        {
            var product = await db.Products.GetAsync(id);

            var result = mapper.Map<ProductDTO>(product);

            return result;
        }

        public async Task CreateAsync(ProductDTO item)
        {
            var newProduct = mapper.Map<Product>(item);

            await db.Products.CreateAsync(newProduct);
        }

        public async Task UpdateAsync(ProductDTO item)
        {
            var updateProduct = mapper.Map<Product>(item);

            await db.Products.UpdateAsync(updateProduct);
        }

        public async Task DeleteAsync(int id)
        {
            await db.Products.DeleteAsync(id);
        }
    }
}
