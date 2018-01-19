using System;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFX.Core.BaseModel;
using MyFX.Core.DI;
using MyFX.Core.Repository;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Service;

namespace MyFX.Repository.Test
{
    [TestClass]
    public class Order_Test
    {
        private IContainer GetContainer()
        {
            Bootstrapper.Current.Start();
            return Bootstrapper.Current.Container;
        }

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
            var ci = GetContainer();
            var uow = ci.Resolve<IUnitOfWorkFactory>().Create();
            IOrderRepository rep = ci.Resolve<IOrderRepository>();
            rep.Add(new Order()
            {
               OrderNo = "6999999999999",
               CustomerId = 9986755,
               OrderStatus = 80,
               OrderType = 10,
               StoreId = 7788,
               StoreOwnerId = 9900
            });

            uow.Commit();
        }

        [TestMethod]
        public void AddOrders_Test1()
        {
            var ci = GetContainer();
            var orderService = ci.Resolve<IOrderService>();
            var order = new Order()
            {
                OrderNo = "11122233344455888",
                CustomerId = 9986755,
                OrderStatus = 80,
                OrderType = 10,
                StoreId = 7788,
                StoreOwnerId = 9900
            };
            orderService.CreateOrder(order);
        }


        [TestMethod]
        public void Orders_Test()
        {
            var ci = GetContainer();
            IOrderRepository rep = ci.Resolve<IOrderRepository>();
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
            var ci = GetContainer();
            IOrderRepository rep = ci.Resolve<IOrderRepository>();
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
