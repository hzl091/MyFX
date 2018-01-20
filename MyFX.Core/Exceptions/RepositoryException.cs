using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 仓储层异常基类
    /// </summary>
    [Serializable]
    public class RepositoryException : MyFXException
    {
        public RepositoryException()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        public RepositoryException(string message) : base(message) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public RepositoryException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
