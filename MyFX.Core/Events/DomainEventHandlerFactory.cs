/****************************************************************************************
 * 文件名：DomainEventHandlerFactory
 * 作者：huangzl
 * 创始时间：2018/2/1 17:42:51
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
    /// 领域事件处理者工厂
    /// </summary>
    internal static class EventHandlerFactory
    {
        /// <summary>
        /// 获取领域事件处理者实例集合
        /// </summary>
        /// <typeparam name="TDomainEvent">领域事件类型</typeparam>
        /// <returns>领域事件处理者集合</returns>
        public static IEnumerable<IDomainEventHandler<TDomainEvent>> GetEventHandlers<TDomainEvent>() 
            where TDomainEvent : class, IDomainEvent
        {
            return DIBootstrapper.Container.ResolveAll<IDomainEventHandler<TDomainEvent>>();
        }
    }
}
