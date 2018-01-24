using System;
using System.Collections;
using System.Runtime.Serialization;
using MyFX.Core.Exceptions;
using Newtonsoft.Json;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 结果对象
    /// </summary>
    public class ResultObject : IResultObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ResultObject()
        {
            this.BuildResultObject(ResultObjectCodes.Success, "");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="retStatus">状态码</param>
        /// <param name="retMsg">消息</param>
        public ResultObject(int retStatus, string retMsg)
        {
            this.BuildResultObject(retStatus, retMsg);
        }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty(PropertyName = "retStatus")]
        public int StatusCode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty(PropertyName = "retMsg")]
        public string Message { get; set; }
        
        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        [JsonProperty(PropertyName = "retErrorBody")]
        public object ErrorBody { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty(PropertyName = "isOk")]
        public bool IsOk
        {
            get { return StatusCode == ResultObjectCodes.Success; }
            set { }
        }
    }
}
