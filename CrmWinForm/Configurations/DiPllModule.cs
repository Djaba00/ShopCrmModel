using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShopCRM.BLL.Configurations;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmWinForm.Configurations
{
    public static class DIPllModule
    {
        public static IServiceCollection AddPLLServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfilePLL());
                v.AddProfile(new MappingProfileBLL());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddTransient<ICheckService, CheckService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISellerService, SellerService>();
            services.AddTransient<ISellService, SellService>();

            return services;
        }
    }
}
