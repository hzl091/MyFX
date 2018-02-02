/****************************************************************************************
 * 文件名：NameValue
 * 作者：huangzl
 * 创始时间：2018/2/1 16:25:39
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// 名称值对象
    /// </summary>
    public class NameValue<T>
    {
        public NameValue()
        {
        }

        public NameValue(string name, T value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; set; }
    }
}
