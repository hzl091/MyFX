using System;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFX.Core.Base;
using MyFX.Core.BaseModel;
using MyFX.Core.BaseModel.Paging;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.DI;
using MyFX.Core.Domain.Uow;
using MyFX.Core.Events;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Domain.Events;
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
            var order = new Order()
            {
                OrderNo = "6999999999999",
                CustomerId = 9986755,
                OrderStatus = 80,
                OrderType = 10,
                StoreId = 7788,
                StoreOwnerId = 9900
            };
            rep.Add(order);

            EventBus.Publish(new OrderCreatedEvent()
            {
                OrderNo = order.OrderNo,
                CustomerName = "zzzz",
                Email = "hzl091@126.com"
            });

            order.Cancel("无货");
            EventBus.Publish(new OrderCanceledEvent()
            {
                OrderNo = order.OrderNo,
                CustomerName = "zzzz",
                Reason = "无货"
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
            Console.WriteLine(rs.DataBody.CustomerId); 
        }

        [TestMethod]
        public void Service_FindOrders_Test1()
        {
            var ci = GetContainer();
            var orderService = ci.Resolve<IOrderService>();

            var rs = orderService.FindOrders(new FindOrdersRequest() {PageIndex = 1, PageSize = 2});
            if (rs.IsOk)
            {
                var orders = rs.DataBody.Rows;
                foreach (var order in orders)
                {
                    Console.WriteLine(order.OrderNo);
                }
                Console.WriteLine("total:" + rs.DataBody.TotalCount);
            }
            else
            {
                Console.WriteLine(rs.Message);
            }
            
        }

        [TestMethod]
        public void Service_FindOrdersToPage_Test1()
        {
            var ci = GetContainer();
            var orderService = ci.Resolve<IOrderService>();

            var rs = orderService.FindOrdersToPage(new PageRequestBase() { PageIndex = 1, PageSize = 2 });
            if (rs.IsOk)
            {
                var orders = rs.List;
                foreach (var order in orders)
                {
                    Console.WriteLine(order.OrderNo);
                }
                Console.WriteLine("total:" + rs.TotalCount);
            }
            else
            {
                Console.WriteLine(rs.Message);
            }

        }
    }
}
