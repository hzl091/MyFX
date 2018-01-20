using System;

namespace MyFX.Core.Exceptions
{
    /// <summary>
    /// MyFX异常基类
    /// </summary>
    [Serializable]
    public class MyFXException : System.Exception
    {
        public MyFXException()
        {
        }

        public MyFXException(string message, string exceptionCode = "")
            : base(message)
        {
            this.Code = exceptionCode;
        }

        public MyFXException(string format, string message, string exceptionCode = "")
            : base(string.Format(format, message))
        {
            this.Code = exceptionCode;
        }

        /// <summary>
        /// 用于异常时返回相关业务数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public MyFXException AddData(string key, object value)
        {
            if (Data.Contains(key))
            {
                throw new MyFXException(string.Format("key[{0}]重复", key));
            }

            Data[key] = value;
            return this;
        }

        /// <summary>
        /// 异常代码，用来快速定位异常和区分异常归属系统。
        /// </summary>
        public string Code
        {
            get;
            protected set;
        }
    }
}
