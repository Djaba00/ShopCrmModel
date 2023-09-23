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

            services.AddScoped<ICheckService, CheckService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ISellService, SellService>();
            services.AddScoped<ICashDeskService, CashDeskService>();

            return services;
        }
    }
}
