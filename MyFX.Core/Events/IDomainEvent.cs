using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.Events
{
    /// <summary>
    /// 领域事件模型
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象
        /// </summary>
        object EventSource { get; set; }
    }
}
