/****************************************************************************************
 * 文件名：DateTimeExtension
 * 作者：黄泽林
 * 创始时间：2018/1/20 9:28:15
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 提供时间相关扩展方法。
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 对时间格式化为字符串。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string DateFormatString(this DateTime format)
        {
            return format.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// 对当前时间格式化为字符串。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string DateNowString(this DateTime format)
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// 对最小时间格式化为字符串。
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string DateMinString(this DateTime format)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
