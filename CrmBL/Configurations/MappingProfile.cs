using AutoMapper;
using ShopCRM.DAL.Entities;

namespace ShopCRM.BLL.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CheckDTO, Check>();
            CreateMap<Check, CheckDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<SellDTO, Sell>();
            CreateMap<Sell, SellDTO>();

            CreateMap<SellerDTO, Seller>();
            CreateMap<Seller, SellerDTO>();

        }
    }
}
