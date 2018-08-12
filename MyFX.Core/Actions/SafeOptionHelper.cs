using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Validations;

namespace MyFX.Core.Actions
{
    public class SafeOptionHelper
    {
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject Execute<TResultObject>(Func<TResultObject> func, bool throwException = false)
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleServiceOption<DefaultRequest, TResultObject>(new DefaultRequest(), null, func);
            return opt.DoExecute(throwException);
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="TRequest">请求对象类型</typeparam>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="request">请求</param>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject Execute<TRequest, TResultObject>(TRequest request, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleServiceOption<TRequest, TResultObject>(request, null, func);
            return opt.DoExecute(throwException);
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="TRequest">请求对象类型</typeparam>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="request">请求</param>
        /// <param name="requestValidator">请求验证器</param>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject Execute<TRequest, TResultObject>(TRequest request, IValidator requestValidator, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleServiceOption<TRequest, TResultObject>(request, requestValidator, func);
            return opt.DoExecute(throwException);
        }

        /// <summary>
        /// 执行带事务的操作
        /// </summary>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject ExecuteTransaction<TResultObject>(Func<TResultObject> func, bool throwException = false)
           where TResultObject : IResultObject, new()
        {
            var opt = new SimpleTransactionServiceOption<DefaultRequest, TResultObject>(new DefaultRequest(), null, func);
            return opt.DoExecute(throwException);
        }
        
        /// <summary>
        /// 执行带事务的操作
        /// </summary>
        /// <typeparam name="TRequest">请求对象类型</typeparam>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="request">请求</param>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject ExecuteTransaction<TRequest, TResultObject>(TRequest request, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleTransactionServiceOption<TRequest, TResultObject>(request, null, func);
            return opt.DoExecute(throwException);
        }

        /// <summary>
        /// 执行带事务的操作
        /// </summary>
        /// <typeparam name="TRequest">请求对象类型</typeparam>
        /// <typeparam name="TResultObject">返回对象类型</typeparam>
        /// <param name="request">请求</param>
        /// <param name="requestValidator">请求验证器</param>
        /// <param name="func">要执行的具体业务</param>
        /// <param name="throwException">是否抛出异常</param>
        /// <returns>返回结果对象</returns>
        public static TResultObject ExecuteTransaction<TRequest, TResultObject>(TRequest request, IValidator requestValidator, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleTransactionServiceOption<TRequest, TResultObject>(request, requestValidator, func);
            return opt.DoExecute(throwException);
        } 
    }

    
    public class SimpleServiceOption<TRequest, TResultObject> : ServiceOptionBase<TRequest, TResultObject>
        where TRequest : IRequest
        where TResultObject : IResultObject, new()
    {
        private readonly Func<TResultObject> _func;
        public SimpleServiceOption(TRequest request, IValidator requestValidator, Func<TResultObject> func) 
            : base(request)
        {
            if (requestValidator != null)
            {
                this.SetValidator(requestValidator);
            }
            _func = func;
        }

        protected override TResultObject Execute()
        {
            return this._func();
        }
    }

    public class SimpleTransactionServiceOption<TRequest, TResultObject> :
        TransactionServiceOptionBase<TRequest, TResultObject>
        where TRequest : IRequest
        where TResultObject : IResultObject, new()
    {
        private readonly Func<TResultObject> _func;
        public SimpleTransactionServiceOption(TRequest request,IValidator requestValidator, Func<TResultObject> func) 
            : base(request)
        {
            if (requestValidator != null)
            {
                this.SetValidator(requestValidator);
            }
            _func = func;
        }

        protected override TResultObject Execute()
        {
            return this._func();
        }
    }
}
