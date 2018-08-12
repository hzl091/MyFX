using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.BaseModel.Result;

namespace MyFX.Core.Actions
{
    public class SafeOptionHelper
    {
        public static TResultObject Execute<TRequest, TResultObject>(TRequest request, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleServiceOption<TRequest, TResultObject>(request, func);
            return opt.DoExecute(throwException);
        }

        public static TResultObject ExecuteTransaction<TRequest, TResultObject>(TRequest request, Func<TResultObject> func, bool throwException = false)
            where TRequest : IRequest
            where TResultObject : IResultObject, new()
        {
            var opt = new SimpleTransactionServiceOption<TRequest, TResultObject>(request, func);
            return opt.DoExecute(throwException);
        }
    }

    
    public class SimpleServiceOption<TRequest, TResultObject> : ServiceOptionBase<TRequest, TResultObject>
        where TRequest : IRequest
        where TResultObject : IResultObject, new()
    {
        private readonly Func<TResultObject> _func;
        public SimpleServiceOption(TRequest request, Func<TResultObject> func) 
            : base(request)
        {
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
        public SimpleTransactionServiceOption(TRequest request, Func<TResultObject> func) 
            : base(request)
        {
            _func = func;
        }

        protected override TResultObject Execute()
        {
            return this._func();
        }
    }
}
