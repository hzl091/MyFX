using System;
using System.Collections;
using MyFX.Core.Exceptions;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 结果对象
    /// </summary>
    //[DataContract]
    public class ResultObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ResultObject()
        {
            BuildResultObject(ResultObjectCodes.Success, "");
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
        /// 检测返回结果是否有错误，如果有错误则抛异常
        /// </summary>
        public void CheckErrorAndThrowIt()
        {
            if (this.retStatus != ResultObjectCodes.Success)
            {
                var ex = new MyFXException(this.retMsg, this.retStatus.ToString());
                var dic = retErrorBody as IDictionary;
                if (dic != null && dic.Count > 0)
                {
                    foreach (DictionaryEntry o in dic)
                    {
                        ex.AddData(o.Key.ToString(), o.Value);
                    } 
                }

                throw ex;
            }
        }

        /// <summary>
        /// 验证失败
        /// </summary>
        /// <param name="msg"></param>
        public void ValidateFailed(string msg)
        {
            this.BuildResultObject(ResultObjectCodes.ValidateFailed, msg, null);
        }

        /// <summary>
        /// 服务异常
        /// </summary>
        /// <param name="ex"></param>
        public void ServerException(Exception ex)
        {
            this.BuildResultObject(ResultObjectCodes.ServerError, ex.Message);
        }

        /// <summary>
        /// 服务异常
        /// </summary>
        /// <param name="msg"></param>
        public void ServerException(string msg)
        {
            this.BuildResultObject(ResultObjectCodes.ServerError, msg);
        }

        /// <summary>
        /// 资源未找到
        /// </summary>
        /// <param name="msg"></param>
        public void NoFound(string msg)
        {
            this.BuildResultObject(ResultObjectCodes.NoFound, msg);
        }

        /// <summary>
        /// 操作被禁止
        /// </summary>
        /// <param name="msg"></param>
        public void OperationForbidden(string msg)
        {
            this.BuildResultObject(ResultObjectCodes.OperationForbidden, msg);
        }

        /// <summary>
        /// 结果对象构建
        /// </summary>
        /// <param name="retStatus"></param>
        /// <param name="retMsg"></param>
        /// <param name="retErrorBody"></param>
        public void BuildResultObject(int retStatus, string retMsg, object retErrorBody = null)
        {
            this.retStatus = retStatus;
            this.retMsg = retMsg;
            this.retErrorBody = retErrorBody;
            this.isOk = this.retStatus == ResultObjectCodes.Success;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        //[DataMember]
        public int retStatus { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        //[DataMember]
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
