/****************************************************************************************
 * 文件名：BatchResultObject
 * 作者：huangzl
 * 创始时间：2017/8/8 11:26:28
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// /批量操作结果
    /// </summary>
    public class BatchResultObject : ResultObject
    {
        public BatchResultObject()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="totalCount">操作总数量</param>
        /// <param name="successTotal">操作成功总数量</param>
        /// <param name="faildTotal">操作失败总数量</param>
        public BatchResultObject(int totalCount, int successTotal, int faildTotal)
            : this()
        {
            TotalCount = totalCount;
            SuccessTotal = successTotal;
            FaildTotal = faildTotal;
        }

        /// <summary>
        /// 操作总数量
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 操作成功总数量
        /// </summary>
        [JsonProperty(PropertyName = "successTotal")]
        public int SuccessTotal { get; set; }

        /// <summary>
        /// 操作失败总数量
        /// </summary>
        [JsonProperty(PropertyName = "faildTotal")]
        public int FaildTotal { get; set; }
    }
}
