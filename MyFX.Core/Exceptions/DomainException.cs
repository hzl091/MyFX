using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 领域层异常基类
    /// </summary>
    [Serializable]
    public class DomainException : MyFXException
    {
        public DomainException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public DomainException(string message) : base(message) { }

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public DomainException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
