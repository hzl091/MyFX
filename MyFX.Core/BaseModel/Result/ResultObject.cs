using System;
using System.Collections;
using System.Runtime.Serialization;
using MyFX.Core.Exceptions;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 结果对象
    /// </summary>
   [DataContract]
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
        [DataMember]
        public virtual int retStatus { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [DataMember]
        public virtual string retMsg { get; set; }

        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        [DataMember]
        public virtual object retErrorBody { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [DataMember]
        public virtual bool isOk
        {
            get { return retStatus == ResultObjectCodes.Success; }
            set { }
        }
    }
}
