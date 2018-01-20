/****************************************************************************************
 * 文件名：ValidationException
 * 作者：huangzl
 * 创始时间：2017/10/24 15:32:30
 * 创建说明：
****************************************************************************************/

using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 验证失败异常
    /// </summary>
    [Serializable]
    public class ValidationException : MyFXException
    {
        public ValidationException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public ValidationException(string message) : base(message) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public ValidationException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
