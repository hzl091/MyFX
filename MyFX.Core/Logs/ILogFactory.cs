using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.Logs
{
    /// <summary>
    /// 日志器工厂
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// 获取通用日志器
        /// </summary>
        /// <returns></returns>
        ILog GetCommonLog();

        /// <summary>
        /// 获取错误日志器
        /// </summary>
        /// <returns></returns>
        ILog GetErrorLog();
    }
}
