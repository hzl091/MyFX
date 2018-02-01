/****************************************************************************************
 * 文件名：DomainEvent
 * 作者：huangzl
 * 创始时间：2018/2/1 9:26:18
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.Events
{
    /// <summary>
    /// 领域事件基类
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            EventTime = DateTime.Now;
        }

        public DomainEvent(object eventSource)
            : this()
        {
            EventSource = eventSource;
        }

        /// <summary>
        /// 时间触发时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 事件源对象
        /// </summary>
        public object EventSource { get; set; }
    }
}
