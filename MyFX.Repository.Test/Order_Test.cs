using System;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFX.Core.Base;
using MyFX.Core.BaseModel;
using MyFX.Core.BaseModel.Paging;
using MyFX.Core.DI;
using MyFX.Core.Domain.Uow;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Dtos.Request;
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

            var pagedList = rep.FindPageList(new PagedQuery() { PageIndex = 2, PageSize = 2 }, null, sorts);
            var orders = pagedList.Rows;
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
            var pagedList = rep.FindPageList(new PagedQuery() { PageIndex = 2, PageSize = 2 }, null, o =>o.OrderNo);
            var orders = pagedList.Rows;
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderNo);
            }
            Console.WriteLine("total:" + total);
        }


        [TestMethod]
        public void Service_GetOrder_Test1()
        {
            var ci = GetContainer();
            var orderService = ci.Resolve<IOrderService>();

            var rs = orderService.GetOrder(new GetOrderRequest() { OrderNo = "66666588888" });
            Console.WriteLine(rs.ToJsonString());
            Console.WriteLine(rs.retBody.CustomerId); 
        }

        [TestMethod]
        public void Service_FindOrders_Test1()
        {
            var ci = GetContainer();
            var orderService = ci.Resolve<IOrderService>();

            var rs = orderService.FindOrders(new FindOrdersRequest() {PageIndex = 1, PageSize = 2});
            if (rs.isOk)
            {
                var orders = rs.retBody.Rows;
                foreach (var order in orders)
                {
                    Console.WriteLine(order.OrderNo);
                }
                Console.WriteLine("total:" + rs.retBody.TotalCount);
            }
            else
            {
                Console.WriteLine(rs.retMsg);
            }
            
        }
    }
}
