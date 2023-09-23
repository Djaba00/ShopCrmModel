using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCRM.BLL.ComputerModel;
using AutoMapper;
using ShopCRM.BLL.Configurations;

namespace CrmBL.Models.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        IMapper mapper;

        public ShopComputerModelTests()
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfileBLL());
            });

            IMapper mapper = mapperConfig.CreateMapper();
        }

        [TestMethod()]
        public void StartTest()
        {
            var model = new ShopComputerModel(mapper);
            model.Start();
            Thread.Sleep(10000);
        }
    }
}