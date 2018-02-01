/****************************************************************************************
 * 文件名：SendOrderCanceledEmailHandler
 * 作者：huangzl
 * 创始时间：2018/2/1 11:42:32
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Repository.Test.Domain.Events;

namespace MyFX.Repository.Test.Domain.EventHandlers
{
    class SendOrderCanceledEmailHandler : MyFX.Core.Events.IDomainEventHandler<OrderCanceledEvent>
    {
        public void Handle(OrderCanceledEvent evt)
        {
            Console.WriteLine(string.Format("顾客[{0}]您好:由于[{1}]，订单[{2}]已被取消", evt.CustomerName, evt.Reason, evt.OrderNo));
        }
    }
}
