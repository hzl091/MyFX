using System;

namespace MyFX.Core.Base
{
    /// <summary>
    /// 异常助手类
    /// </summary>
    public static class ThrowHelper
    {
        public static void ThrowIfArgumentNull(object paramValue, string paramName)
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ThrowIfArgumentNull(object paramValue, string paramName, string message)
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void ThrowIfArgumentNullOrEmpty(string paramValue, string paramName)
        {
            ThrowIfArgumentNull(paramValue, paramName);
            if (String.IsNullOrEmpty(paramValue.Trim()))
            {
                throw new ArgumentException(String.Format("Parameter '{0}' could be empty", paramName));
            }
        }

        public static void ThrowIfArgumentEmpty(string paramValue, string paramName)
        {
            if (String.IsNullOrEmpty(paramValue.Trim()))
            {
                throw new ArgumentException(String.Format("Parameter '{0}' could be empty", paramName));
            }
        }

        public static void ThrowIfArgumentNullOrEmpty(Array paramValue, string paramName)
        {
            ThrowIfArgumentNull(paramValue, paramName);
            if (paramValue.Length <= 0)
            {
                throw new ArgumentException(String.Format("Parameter '{0}' could be empty", paramName));
            }
        }

        public static void ThrowIfArgumentEmpty(Array paramValue, string paramName)
        {
            if (paramValue.Length <= 0)
            {
                throw new ArgumentException(String.Format("Parameter '{0}' could be empty", paramName));
            }
        }

        public static void ThrowArgumentOutOfRangeInvalidEnum(long enumValue, string paramName)
        {
            throw ArgumentOutOfRangeInvalidEnum(enumValue, paramName);
        }

        public static ArgumentOutOfRangeException ArgumentOutOfRangeInvalidEnum(long enumValue, string paramName)
        {
            return new ArgumentOutOfRangeException(paramName, String.Format("Invalid enum value '{0}'", enumValue));
        }
    }
}
