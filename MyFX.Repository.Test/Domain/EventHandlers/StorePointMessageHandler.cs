/****************************************************************************************
 * 文件名：StorePointMessageHandler
 * 作者：huangzl
 * 创始时间：2018/2/1 11:33:34
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
    /// <summary>
    /// 积分消息处理者
    /// </summary>
    public class StorePointMessageHandler : MyFX.Core.Events.IDomainEventHandler<OrderCreatedEvent>
    {
        public void Handle(OrderCreatedEvent evt)
        {
            Console.WriteLine(string.Format("顾客[{0}]您好:订单[{1}]已提交成功,积分已入账", evt.CustomerName, evt.OrderNo));
        }
    }
}
