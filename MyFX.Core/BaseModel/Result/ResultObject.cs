using System;
using System.Collections;
using MyFX.Core.Exceptions;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 结果对象
    /// </summary>
    [Serializable]
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
        public int retStatus { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string retMsg { get; set; }

        /// <summary>
        /// 异常时返回的业务数据
        /// </summary>
        public object retErrorBody { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isOk { get; set; }
    }
}
