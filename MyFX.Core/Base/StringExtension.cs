using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 提供字符串相关扩展方法。
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 对格式字符串进行格式化。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string FormatString(this string format, object arg)
        {
            return string.Format(format, arg);
        }

        /// <summary>
        /// 对格式字符串进行格式化。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static string FormatString(this string format, object arg1, object arg2)
        {
            return string.Format(format, arg1, arg2);
        }

        /// <summary>
        /// 对格式字符串进行格式化。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static string FormatString(this string format, object arg1, object arg2, object arg3)
        {
            return string.Format(format, arg1, arg2, arg3);
        }

        /// <summary>
        /// 对格式字符串进行格式化。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatString(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// 对格式字符串进行格式化。
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatString(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }


        /// <summary>
        /// 删除特殊字符.默认为(< > ' \ &)
        /// 如果字符串为空，直接返回。
        /// </summary>
        /// <param name="str">需要过滤的字符串</param>
        /// <returns>过滤好的字符串</returns>
        public static string RemoveSpcialChar(this string str)
        {
            string[] chars = new string[] { "<", ">", "&", "'", "\"" };
            return str.RemoveSpcialChar(chars);
        }

        /// <summary>
        /// 过滤特殊字符
        /// 如果字符串为空，直接返回。
        /// </summary>
        /// <param name="str">需要过滤的字符串</param>
        /// <param name="spcialChar"></param>
        /// <returns>过滤好的字符串</returns>
        public static string RemoveSpcialChar(this string str, string[] spcialChar)
        {
            if (str == "")
            {
                return str;
            }
            return spcialChar.Aggregate(str, (current, c) => current.Replace(c, ""));
        }   

        /// <summary>
        /// 使用逗号对字符串进行分割。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] SplitByComma(this string s)
        {
            return s.Split(',');
        }

        /// <summary>
        /// 判断所有字符是否都是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsAllNumber(this string value)
        {
            return value.All(char.IsNumber);
        }

        /// <summary>
        /// 转换为Int类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultZero">设置默认值为0</param>
        /// <returns></returns>
        public static int ToInt(this string value, bool defaultZero = true)
        {
            int val = 0;
            if (int.TryParse(value, out val))
            {
                return val;
            }
            return 0;
        }
    }
}
