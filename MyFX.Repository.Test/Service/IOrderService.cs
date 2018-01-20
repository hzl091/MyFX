/****************************************************************************************
 * 文件名：IOrderService
 * 作者：huangzl
 * 创始时间：2018/1/18 17:30:43
 * 创建说明：
****************************************************************************************/

using MyFX.Core.DI;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Dtos.Request;
using MyFX.Repository.Test.Dtos.Response;

namespace MyFX.Repository.Test.Service
{
    public interface IOrderService : IDependency
    {
        void CreateOrder(Order order);

        GetOrderResult GetOrder(GetOrderRequest request);

        FindOrdersResult FindOrders(FindOrdersRequest request);
    }
}
