using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// UI层异常基类
    /// </summary>
    [Serializable]
    public class UIException : MyFXException
    {
        public UIException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public UIException(string message) : base(message) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public UIException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        /// <param name="innerException">内部异常</param>
        public UIException(string message, int errorCode, Exception innerException)
            : base(message, errorCode.ToString(), innerException)
        {
        }
    }
}
