/****************************************************************************************
 * 文件名：OrderCreatedEvent
 * 作者：huangzl
 * 创始时间：2018/2/1 11:20:18
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Repository.Test.Domain.Events
{
    public class OrderCreatedEvent : MyFX.Core.Events.DomainEvent
    {
        public string OrderNo { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }
    }
}
