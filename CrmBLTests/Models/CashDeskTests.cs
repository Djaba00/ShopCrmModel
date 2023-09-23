using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCRM.DAL.Entities;
using ShopCRM.BLL.BusinesModels;
using AutoMapper;
using ShopCRM.BLL.Configurations;
using ShopCRM.BLL.DTO;

namespace CrmBL.Models.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        IMapper mapper;

        public CashDeskTests()
        {
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfileBLL());
            });

            IMapper mapper = mapperConfig.CreateMapper();
        }

        [TestMethod()]
        public async void CashDeskTest()
        {
            // Arrange

            var customer1 = new CustomerDTO()
            {
                CustomerId = 1,
                Name = "Tester1"
            };

            var customer2 = new CustomerDTO()
            {
                CustomerId = 2,
                Name = "Tester2"
            };

            var seller = new SellerDTO()
            {
                SellerId = 1,
                Name = "Seller1"
            };

            var product1 = new ProductDTO()
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };

            var product2 = new ProductDTO()
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };

            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            var cart2 = new Cart(customer1);
            cart2.Add(product2);
            cart2.Add(product1);
            cart2.Add(product2);

            var cashDesk = new CashDesk(1, seller, null, mapper)
            {
                MaxQueueLenght = 10
            };
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);

            var cart1ExpectedResult = 400;

            var cart2ExpectedResult = 500;

            // Act

            var cart1ActualResult = await cashDesk.Dequeue();

            var cart2ActualResult = await cashDesk.Dequeue();

            // Assert

            // Сумма товаров в корзинах
            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);

            // Проверка количества товара
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(17, product2.Count);
        }
    }
}