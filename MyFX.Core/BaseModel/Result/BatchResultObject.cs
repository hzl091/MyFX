/****************************************************************************************
 * 文件名：BatchResultObject
 * 作者：huangzl
 * 创始时间：2017/8/8 11:26:28
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// /批量操作结果
    /// </summary>
    [Serializable]
    public class BatchResultObject : ResultObject
    {
        /// <summary>
        /// 操作总数量
        /// </summary>
        //[DataMember]
        public int TotalCount { get; set; }

        /// <summary>
        /// 操作成功数量
        /// </summary>
        //[DataMember]
        public int SuccessCount { get; set; }

        /// <summary>
        /// 执行失败对象唯一标识集合
        /// </summary>
        //[DataMember]
        public List<string> FailIdCodes { get; set; }
    }
}
