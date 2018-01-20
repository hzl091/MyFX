/****************************************************************************************
 * 文件名：DecimalExtension
 * 作者：huangzl
 * 创始时间：2017/10/12 11:10:59
 * 创建说明：
****************************************************************************************/

using System;
using System.ComponentModel;
using System.Reflection;

namespace MyFX.Core.Base
{
    /// <summary>
    ///  提供枚举相关扩展方法。
    /// </summary>
    public static class EnumExtension
    {  
        #region GetInstance(获取实例)

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名或值,
        /// 范例:Enum1枚举有成员A=0,则传入"A"或"0"获取 Enum1.A</param>
        public static T GetInstance<T>(object member)
        {
            string value = ToString(member);
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("member");
            return (T)System.Enum.Parse(GetType<T>(), value, true);
        }

        #endregion

        #region GetName(获取成员名)

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可,
        /// 范例:Enum1枚举有成员A=0,则传入Enum1.A或0,获取成员名"A"</param>
        public static string GetName<T>(object member)
        {
            return GetName(GetType<T>(), member);
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetName(Type type, object member)
        {
            if (type == null)
                return string.Empty;
            if (member == null)
                return string.Empty;
            if (member is string)
                return member.ToString();
            if (type.IsEnum == false)
                return string.Empty;
            return System.Enum.GetName(type, member);
        }

        #endregion

        #region GetValue(获取成员值)

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可，
        /// 范例:Enum1枚举有成员A=0,可传入"A"、0、Enum1.A，获取值0</param>
        public static int GetValue<T>(object member)
        {
            return GetValue(GetType<T>(), member);
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static int GetValue(Type type, object member)
        {
            string value = ToString(member);
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("member");
            return (int)System.Enum.Parse(type, member.ToString(), true);
        }

        #endregion

        #region GetDescription(获取描述)

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription<T>(object member)
        {
            return GetDescription<T>(GetName<T>(member));
        }

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription(Type type, object member)
        {
            FieldInfo field = type.GetField(member.ToString());
            if (field == null)
            {//member不是当前枚举项时,field为null;如枚举未定义值为0的枚举项,而member为0.
                return string.Empty;
            }
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? member.ToString() : attribute.Description;
        }

        #endregion

        #region 对枚举类型进行扩展
        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static string Description(this System.Enum instance)
        {
            return GetDescription(instance.GetType(), instance);
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static int Value(this System.Enum instance)
        {
            return GetValue(instance.GetType(), instance);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取类型,对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        private static Type GetType<T>()
        {
            return Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        private static string ToString(object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="memberName">成员名称</param>
        private static string GetDescription<T>(string memberName)
        {
            return GetDescription(GetType<T>(), memberName);
        }
        #endregion
    }
}
