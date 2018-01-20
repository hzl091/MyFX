/****************************************************************************************
 * 文件名：TransactionServiceOptionBase
 * 作者：huangzl
 * 创始时间：2017/11/9 16:09:33
 * 创建说明：
****************************************************************************************/

using System.Transactions;
using MyFX.Core.BaseModel;
using MyFX.Core.BaseModel.Result;

namespace MyFX.Core.Actions
{
    /// <summary>
    /// 支持分布式事务的服务操作基类
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class TransactionServiceOptionBase<TRequest, TResponse> : ServiceOptionBase<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : ResultObject, new()
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request"></param>
        public TransactionServiceOptionBase(TRequest request)
            : base(request)
        {
        }

        public override TResponse DoExecute(bool throwException = false)
        {
            using (var trans = new TransactionScope())
            {
                TResponse res = base.DoExecute(throwException);
                if (res.isOk) { trans.Complete(); }
                return res;
            }           
        }
    }
}
