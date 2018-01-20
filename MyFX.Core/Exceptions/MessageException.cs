using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// 消息异常
    /// </summary>
    [Serializable]
    public class MessageException :MyFXException
    {
        public MessageException(string message)
            : base(message)
        {
        }

         /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="errorCode">错误code</param>
        public MessageException(string message, int errorCode)
            : base(message, errorCode.ToString())
        {
        }
    }
}
