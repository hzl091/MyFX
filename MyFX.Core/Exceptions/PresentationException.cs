using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 表现层异常基类
    /// </summary>
    [Serializable]
    public class PresentationException : MyFXException
    {
        public PresentationException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public PresentationException(string message) : base(message) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public PresentationException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        /// <param name="innerException">内部异常</param>
        public PresentationException(string message, int errorCode, Exception innerException)
            : base(message, errorCode.ToString(), innerException)
        {
        }
    }
}
