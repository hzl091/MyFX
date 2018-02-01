/****************************************************************************************
 * 文件名：SendOrderReceivedEmailHandler
 * 作者：huangzl
 * 创始时间：2018/2/1 11:23:56
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.Events;
using MyFX.Repository.Test.Domain.Events;

namespace MyFX.Repository.Test.Domain.EventHandlers
{
    /// <summary>
    /// 订单收到邮件发送处理者
    /// </summary>
    public class SendOrderReceivedEmailHandler : MyFX.Core.Events.IDomainEventHandler<OrderCreatedEvent>
    {
        public void Handle(OrderCreatedEvent evt)
        {
            Console.WriteLine(string.Format("顾客[{0}]您好:订单[{1}]已提交成功,详细信息已发送到[{2}]邮箱，请注意查收", evt.CustomerName, evt.OrderNo, evt.Email));
        }
    }
}
