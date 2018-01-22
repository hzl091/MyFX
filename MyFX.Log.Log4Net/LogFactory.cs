/****************************************************************************************
 * 文件名：LogFactory
 * 作者：huangzl
 * 创始时间：2018/1/22 17:13:01
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.Logs;

namespace MyFX.Log.Log4Net
{
    public class LogFactory : ILogFactory
    {
        public ILog GetCommonLog()
        {
            return new Log("CommonLog");
        }

        public ILog GetErrorLog()
        {
            return new Log("ErrorLog");
        }
    }
}
