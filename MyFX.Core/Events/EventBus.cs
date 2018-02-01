/****************************************************************************************
 * 文件名：EventBus
 * 作者：huangzl
 * 创始时间：2018/2/1 10:18:22
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.DI;

namespace MyFX.Core.Events
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus
    {
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="domainEvent"></param>
        public static void Publish<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : class, IDomainEvent
        {
            IEnumerable<IDomainEventHandler<TDomainEvent>> handlers
                = DIBootstrapper.Container.ResolveAll<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(domainEvent);
            }
        }
    }
}
