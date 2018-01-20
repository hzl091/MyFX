using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 无权限异常
    /// </summary>
    [Serializable]
    public class NoPermissionException : MyFXException
    {
        public NoPermissionException()
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="message">异常消息</param>
        public NoPermissionException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public NoPermissionException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
