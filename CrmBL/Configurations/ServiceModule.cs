using AutoMapper;
using Ninject.Modules;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.Interfaces;
using ShopCRM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCRM.BLL.Configurations
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            Bind<MapperConfiguration>().ToConstant(mapperConfig).InSingletonScope();
            Bind<IMapper>().ToMethod(c => new Mapper(mapperConfig));

            Bind<IContextUnitOfWork>().To<ContextUnitOfWork>();

            Bind<IServiceUnitOfWork>().To<ServiceUnitOfWork>();
        }
    }
}
