using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.DI;

namespace MyFX.Core.Events
{
    /// <summary>
    /// 领域事件处理器
    /// </summary>
    /// <typeparam name="TDomainEvent">领域事件</typeparam>
    public interface IDomainEventHandler<in TDomainEvent> : IEventHandler, IDependency
        where TDomainEvent : IDomainEvent
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="evt"></param>
        void Handle(TDomainEvent evt);
    }
}
