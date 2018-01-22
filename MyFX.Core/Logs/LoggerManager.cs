/****************************************************************************************
 * 文件名：LoggerManager
 * 作者：huangzl
 * 创始时间：2018/1/22 16:16:26
 * 创建说明：
****************************************************************************************/

using System;
using Autofac.Features.GeneratedFactories;

namespace MyFX.Core.Logs
{
    public class LoggerManager
    {
        static LoggerManager()
        {
            ILogFactory fac = DI.DIBootstrapper.Container.Resolve<ILogFactory>();
            CommonLog = fac.GetCommonLog();
            ErrorLog = fac.GetErrorLog();
        }

        /// <summary>
        /// 通用日志记器
        /// </summary>
        public static ILog CommonLog
        {
            get;
            private set;
        }

        /// <summary>
        /// 错误日志记器
        /// </summary>
        public static ILog ErrorLog
        {
            get;
            private set;
        }
    }
}
