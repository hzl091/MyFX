using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 应用程序服务层异常基类
    /// </summary>
    [Serializable]
    public class AppServiceException : MyFXException
    {
        public AppServiceException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public AppServiceException(string message) 
            : base(message) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public AppServiceException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
