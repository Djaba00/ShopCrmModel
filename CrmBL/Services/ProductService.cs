using AutoMapper;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;

namespace ShopCRM.BLL.Services
{
    public class ProductService : IProductService
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

        public async Task<ProductDTO?> CreateAsync(ProductDTO item)
        {
            var newProduct = mapper.Map<Product>(item);

            var result = await db.Products.CreateAsync(newProduct);
            await db.Save();

            return mapper.Map<ProductDTO>(newProduct);
        }

        public async Task UpdateAsync(ProductDTO item)
        {
            var updateProduct = mapper.Map<Product>(item);

            await db.Products.UpdateAsync(updateProduct);
            await db.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await db.Products.DeleteAsync(id);
            await db.Save();
        }
    }
}
