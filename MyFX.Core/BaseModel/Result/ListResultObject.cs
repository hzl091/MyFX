/****************************************************************************************
 * 文件名：ListResultObject
 * 作者：huangzl
 * 创始时间：2018/3/13 10:02:24
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 返回列表数据的结果对象
    /// </summary>
    public class ListResultObject<T> : ResultObject
    {
        /// <summary>
        /// 数据行集合
        /// </summary>
        [JsonProperty(PropertyName = "rows")]
        public IList<T> Rows { get; set; }
    }
}
