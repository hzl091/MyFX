/****************************************************************************************
 * 文件名：Log
 * 作者：huangzl
 * 创始时间：2018/1/22 16:53:59
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using MyFX.Core.Logs;
using log4 = log4net;

namespace MyFX.Log.Log4Net
{
    public class Log : ILog
    {
        private readonly log4.ILog _logProvider = null;
        static Log()
        {
            string configeFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Config\\Log4net.config");
            XmlConfigurator.Configure(new System.IO.FileInfo(configeFile));
        }

        public Log(string name)
        {
            _logProvider = log4.LogManager.GetLogger(name);
        }

        public void Debug(object message)
        {
            _logProvider.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _logProvider.Debug(message, exception);
        }

        public void Info(object message)
        {
            _logProvider.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _logProvider.Info(message, exception);
        }

        public void Warn(object message)
        {
            _logProvider.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _logProvider.Warn(message, exception);
        }

        public void Error(object message)
        {
            _logProvider.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _logProvider.Error(message, exception);
        }

        public void Fatal(object message)
        {
            _logProvider.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _logProvider.Fatal(message, exception);
        }
    }
}
