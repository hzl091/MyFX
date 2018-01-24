/****************************************************************************************
 * 文件名：TransactionServiceOptionBase
 * 作者：huangzl
 * 创始时间：2017/11/9 16:09:33
 * 创建说明：
****************************************************************************************/

using System.Transactions;
using MyFX.Core.BaseModel;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.BaseModel.Result;

namespace MyFX.Core.Actions
{
    /// <summary>
    /// 支持分布式事务的服务操作基类
    /// </summary>
    /// <typeparam name="TRequest">请求类型</typeparam>
    /// <typeparam name="TResultObject">响应类型</typeparam>
    public abstract class TransactionServiceOptionBase<TRequest, TResultObject> : ServiceOptionBase<TRequest, TResultObject>
        where TRequest : IRequest
        where TResultObject : IResultObject, new()
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request"></param>
        public TransactionServiceOptionBase(TRequest request)
            : base(request)
        {
        }

        public override TResultObject DoExecute(bool throwException = false)
        {
            using (var trans = new TransactionScope())
            {
                TResultObject res = base.DoExecute(throwException);
                if (res.IsOk) { trans.Complete(); }
                return res;
            }           
        }
    }
}
