/****************************************************************************************
 * 文件名：OrderService
 * 作者：黄泽林
 * 创始时间：2018/1/18 17:32:19
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Repository.Reps;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test
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
            _uow.Commit();
        }
    }
}
