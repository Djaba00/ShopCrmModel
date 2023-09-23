using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.DTO;


namespace CrmWinForm.Configurations
{
    public class MappingProfilePLL : Profile
    {
        public MappingProfilePLL()
        {
            CreateMap<CheckDTO, CheckViewModel>();
            CreateMap<CheckViewModel, CheckDTO>();

            CreateMap<CustomerDTO, CustomerViewModel>();
            CreateMap<CustomerViewModel, CustomerDTO>();

            CreateMap<ProductDTO, ProductViewModel>();
            CreateMap<ProductViewModel, ProductDTO>();

            CreateMap<SellDTO, SellViewModel>();
            CreateMap<SellViewModel, SellDTO>();

            CreateMap<SellerDTO, SellerViewModel>();
            CreateMap<SellerViewModel, SellerDTO>();

        }
    }
}
