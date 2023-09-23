using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShopCRM.DAL.Interfaces;
using ShopCRM.DAL.Repositories;


namespace ShopCRM.BLL.Configurations
{
    public static class DiBllModule
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IContextUnitOfWork, ContextUnitOfWork>();
            
            return services;
        }
    }
}
