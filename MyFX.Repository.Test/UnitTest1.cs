using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFX.Repository.BaseModel;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetOrders_Test()
        {
            var ctx = new OracleDbContext();
            foreach (var order in ctx.Orders)
            {
                Console.WriteLine(order.OrderNo);
            }

            Assert.AreNotEqual(0, ctx.Orders.Count());
        }

        [TestMethod]
        public void AddOrders_Test()
        {
            OrderRepository rep = new OrderRepository();
            rep.Add(new Order()
            {
               OrderNo = "66666588888",
               CustomerId = 9986755,
               OrderStatus = 80,
               OrderType = 10,
               StoreId = 7788,
               StoreOwnerId = 9900
            });

            rep.Save();
        }

        [TestMethod]
        public void Orders_Test()
        {
            OrderRepository rep = new OrderRepository();
            bool isExists = rep.Exists(o => o.OrderNo.Equals("66666588888"));
            Console.WriteLine(isExists);

            int total = 0;
            var sorts = new SortRule[1];
            sorts[0] = new SortRule()
            {
                PropertyName = "OrderNo",
                IsDesc = false
            };

            var orders = rep.FindPageList(new PageQuery(){PageIndex = 2, PageSize = 2}, out total, null, sorts);
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderNo);
            }
            Console.WriteLine("total:" + total);
        }

        [TestMethod]
        public void Orders_Test1()
        {
            OrderRepository rep = new OrderRepository();
            bool isExists = rep.Exists(o => o.OrderNo.Equals("66666588888"));
            Console.WriteLine(isExists);
            int total = 0;
            var orders = rep.FindPageList(new PageQuery() { PageIndex = 2, PageSize = 2 }, out total, null, o =>o.OrderNo);
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderNo);
            }
            Console.WriteLine("total:" + total);
        }
    }
}
