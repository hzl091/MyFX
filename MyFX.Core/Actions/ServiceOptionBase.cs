/****************************************************************************************
 * 文件名：ServiceOptionBase
 * 作者：huangzl
 * 创始时间：2017/10/24 14:39:05
 * 创建说明：
****************************************************************************************/

using System;
using MyFX.Core.Base;
using MyFX.Core.BaseModel;
using MyFX.Core.BaseModel.Request;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Exceptions;
using MyFX.Core.Logs;
using MyFX.Core.Validations;

namespace MyFX.Core.Actions
{
    /// <summary>
    /// 服务操作基类
    /// </summary>
    /// <typeparam name="TRequest">请求类型</typeparam>
    /// <typeparam name="TResultObject">响应类型</typeparam>
    public abstract class ServiceOptionBase<TRequest, TResultObject> : OptionBase<TRequest, TResultObject>
        where TRequest : IRequest
        where TResultObject : IResultObject, new()
    {
        private IValidator _validator;

        /// <summary>
        /// 请求对象
        /// </summary>
        /// <param name="request"></param>
        public ServiceOptionBase(TRequest request)
            : base(request)
        {
           
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="throwException">是否抛异常，默认为false</param>
        /// <returns></returns>
        public override TResultObject DoExecute(bool throwException = false)
        {
            try
            {
                if (Request == null){ throw new MyFXException("Request不能为空"); }
                this.DoValidate();
                ResultObject = this.Execute();
                if (ResultObject == null) { throw new MyFXException("ResultObject不能为空"); }
            }
            catch (Exception ex)
            {
                Log(ex);//记录日志
                //记录内部异常日志
                if (ex.InnerException != null){ Log(ex.InnerException); }
                if (throwException) { throw; }//根据需求抛出异常
                if (ResultObject == null) { ResultObject = new TResultObject(); }

                var myFxEx = ex as MyFXException;
                if (myFxEx != null)
                {
                    if (!string.IsNullOrEmpty(myFxEx.Code))
                    {
                        ResultObject.StatusCode = myFxEx.Code.ToInt();
                        ResultObject.Message = myFxEx.Message;
                        if (myFxEx.Data.Count > 0)
                        {
                            ResultObject.ErrorBody = myFxEx.Data;
                        }
                    }
                    else
                    {
                        ResultObject.ServerException(ex);
                    } 
                }
                else
                {
                    ResultObject.ServerException(ex);
                }
            }
            return this.ResultObject;
        }

        /// <summary>
        /// 设置请求对象关联的验证器
        /// </summary>
        /// <param name="validator">验证器对象</param>
        public void SetValidator(IValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// 执行验证操作
        /// </summary>
        protected virtual void DoValidate()
        {
            if (_validator == null) { return; }
            Request.Validate(_validator);
        }

        /// <summary>
        /// 执行具体业务操作
        /// </summary>
        protected abstract TResultObject Execute();

        /// <summary>
        /// 记录异常日志信息
        /// </summary>
        public virtual void Log(Exception ex)
        {
            LoggerManager.ErrorLog.Error(ex);
        }
    }
}
