/****************************************************************************************
 * 文件名：OrderService
 * 作者：huangzl
 * 创始时间：2018/1/18 17:32:19
 * 创建说明：
****************************************************************************************/

using MyFX.Core.Repository;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRes { get;set; }
        private IUnitOfWork _uow { get; set; }

        public OrderService(IOrderRepository orderRes, IUnitOfWorkFactory uowFactory)
        {
            _orderRes = orderRes;
            _uow = uowFactory.Create();
        }

        public void CreateOrder(Order order)
        {
            _orderRes.Add(order);
            order.StoreId = 7878789;
            _uow.Commit();
        }
    }
}
