/****************************************************************************************
 * 文件名：FindOrdersCore
 * 作者：huangzl
 * 创始时间：2018/1/22 16:36:29
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.Actions;
using MyFX.Core.BaseModel.Paging;
using MyFX.Core.BaseModel.Request;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Dtos.Request;
using MyFX.Repository.Test.Dtos.Response;
using MyFX.Repository.Test.Service.Validators;

namespace MyFX.Repository.Test.Service.Core
{
    public class FindOrdersCore : ServiceOptionBase<FindOrdersRequest, FindOrdersResult>
    {
        private readonly IOrderRepository _orderRepository = null;

        public FindOrdersCore(FindOrdersRequest request, IOrderRepository orderRepository) 
            : base(request)
        {
            _orderRepository = orderRepository;
            SetValidator(new FindOrdersValidator());
        }

        protected override FindOrdersResult Execute()
        {
            var pagedQuery = Request.ToPagedQuery();
            var pageOrders = _orderRepository.FindPageList(pagedQuery, null, o => o.OrderNo, false);
            FindOrdersResult rs = new FindOrdersResult {DataBody = pageOrders};

            //throw new Exception("出错啦.....");
            return rs;
        }
    }
}
