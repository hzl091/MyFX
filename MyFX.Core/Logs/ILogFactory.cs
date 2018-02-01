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
        /// 按名称获取日志器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ILog GetLog(string name);

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
