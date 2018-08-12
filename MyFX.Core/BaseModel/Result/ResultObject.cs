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
        /// <param name="code">状态码</param>
        /// <param name="msg">消息</param>
        public ResultObject(int code, string msg)
        {
            this.BuildResultObject(code, msg);
        }

        /// <summary>
        /// 返回操作成功结果
        /// </summary>
        /// <returns></returns>
        public static ResultObject Success()
        {
            return new ResultObject();
        }

        /// <summary>
        /// 返回操作失败结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResultObject Fail(int code, string msg)
        {
            return new ResultObject(code, msg);
        }

        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }
        
        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        [JsonProperty(PropertyName = "errorinfo")]
        public object ErrorInfo { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty(PropertyName = "isok")]
        public bool IsOk
        {
            get { return Code == ResultObjectCodes.Success; }
            set { }
        }
    }
}
