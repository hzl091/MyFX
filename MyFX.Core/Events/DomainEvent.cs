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
            this.Id = Guid.NewGuid();
            this.Handled = false;
            this.AddedTime = DateTime.Now;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 时间触发时间
        /// </summary>
        public DateTime AddedTime { get; set; }

        /// <summary>
        /// 是否已处理
        /// </summary>
        public bool Handled { get; set; }
    }
}
