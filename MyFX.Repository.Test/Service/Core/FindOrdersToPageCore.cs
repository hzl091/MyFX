/****************************************************************************************
 * 文件名：FindOrdersToPageCore
 * 作者：huangzl
 * 创始时间：2018/3/13 10:25:11
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
using MyFX.Core.BaseModel.Result;
using MyFX.FluentValidation.Extension.CommonValidators;
using MyFX.Repository.Test.DAL;
using MyFX.Repository.Test.Domain;
using MyFX.Repository.Test.Dtos.Request;
using MyFX.Repository.Test.Dtos.Response;
using MyFX.Repository.Test.Service.Validators;

namespace MyFX.Repository.Test.Service.Core
{
    public class FindOrdersToPageCore : ServiceOptionBase<PageRequestBase, PageResultObject<Order>>
    {
         private readonly IOrderRepository _orderRepository = null;

         public FindOrdersToPageCore(PageRequestBase request, IOrderRepository orderRepository) 
            : base(request)
        {
            _orderRepository = orderRepository;
            SetValidator(new PageRequestBaseValidator());
        }

        protected override PageResultObject<Order> Execute()
        {
            var pagedQuery = new PagedQuery(Request.PageIndex, Request.PageSize);
            var pageOrders = _orderRepository.FindPageList(pagedQuery, null, o => o.OrderNo, false);

            var rs = new PageResultObject<Order>();
            rs.PageSize = pageOrders.PageSize;
            rs.PageCount = pageOrders.PageCount;
            rs.PageIndex = pageOrders.PageIndex;
            rs.TotalCount = pageOrders.TotalCount;
            rs.List = pageOrders.Rows;
            return rs;
        }
    }
}
