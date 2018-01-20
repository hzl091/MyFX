/****************************************************************************************
 * 文件名：DecimalExtension
 * 作者：huangzl
 * 创始时间：2017/12/25 11:03:34
 * 创建说明：
****************************************************************************************/

using System;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 提供Decimal相关扩展方法。
    /// </summary>
    public static class DecimalExtension
    {
        /// <summary>
        /// 四舍五入，保留两位小数
        /// </summary>
        /// <param name="decimalObj">金额</param>
        /// <returns></returns>
        public static decimal Round2(this decimal decimalObj)
        {
            return Decimal.Round(decimalObj, 2);
        }

        /// <summary>
        /// 将小数值按指定的小数位数舍入
        /// </summary>
        /// <param name="decimalObj">金额</param>
        /// <param name="decimals">保留的小数位数</param>
        /// <returns></returns>
        public static decimal Round(this decimal decimalObj, int decimals)
        {
            return Math.Round(decimalObj, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
