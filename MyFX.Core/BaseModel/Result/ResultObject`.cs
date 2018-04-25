using System;
using Newtonsoft.Json;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 相应信息包装类
    /// </summary>
    /// <typeparam name="TBody"></typeparam>
    public class ResultObject<TBody> : ResultObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ResultObject()
            : base()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">要返回的业务数据</param>
        public ResultObject(TBody data) :
            this()
        {
           this.Data = data;
        }

        /// <summary>
        /// 返回的业务数据
        /// </summary>
        [JsonProperty(PropertyName = "retBody")]
        public TBody Data { get; set; }

    }
}
