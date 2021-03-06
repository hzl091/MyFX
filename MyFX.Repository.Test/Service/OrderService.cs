﻿/****************************************************************************************
 * 文件名：OrderService
 * 作者：huangzl
 * 创始时间：2018/1/18 17:32:19
 * 创建说明：
****************************************************************************************/

using MyFX.Core.BaseModel.Paging;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Domain.Uow;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Dtos.Request;
using MyFX.Repository.Test.Dtos.Response;
using MyFX.Repository.Test.Service.Core;

namespace MyFX.Repository.Test.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository { get;set; }
        private IUnitOfWork _uow { get; set; }

        public OrderService(IOrderRepository orderRepository, IUnitOfWork uow)
        {
            _orderRepository = orderRepository;
            _uow = uow;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
            order.StoreId = 7878789;
            _uow.Commit();
        }

        public GetOrderResult GetOrder(GetOrderRequest request)
        {
            var order = _orderRepository.First(o => o.OrderNo.Equals(request.OrderNo));
            GetOrderResult rs = new GetOrderResult();
            rs.Data = order;

            return rs;
        }

        public FindOrdersResult FindOrders(FindOrdersRequest request)
        {
            var core = new FindOrdersCore(request, _orderRepository);
            return core.DoExecute();
        }

        public PageResultObject<Order> FindOrdersToPage(PageRequestBase request)
        {
            var core = new FindOrdersToPageCore(request, _orderRepository);
            return core.DoExecute();
        }
    }
}
