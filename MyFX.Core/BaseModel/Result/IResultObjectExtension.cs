using System;
using System.Collections;
using MyFX.Core.Exceptions;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// IResultObjec扩展
    /// </summary>
    public static class IResultObjectExtension
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resultObject"></param>
        /// <returns></returns>
        public static T To<T>(this IResultObject resultObject) where T : ResultObject ,new()
        {
            if (resultObject == null) { return null; }
            T obj = new T
            {
                StatusCode = resultObject.StatusCode,
                Message = resultObject.Message
            };
            return obj;
        }

        /// <summary>
        /// 结果对象构建
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="retStatus"></param>
        /// <param name="retMsg"></param>
        /// <param name="retErrorBody"></param>
        public static void BuildResultObject(this IResultObject resultObject, int retStatus, string retMsg, object retErrorBody = null)
        {
            resultObject.StatusCode = retStatus;
            resultObject.Message = retMsg;
            resultObject.ErrorBody = retErrorBody;
        }


        /// <summary>
        /// 检测返回结果是否有错误，如果有错误则抛异常
        /// </summary>
        public static void CheckErrorAndThrowIt(this IResultObject resultObject)
        {
            if (resultObject.StatusCode != ResultObjectCodes.Success)
            {
                var ex = new MyFXException(resultObject.Message, resultObject.StatusCode.ToString());
                var dic = resultObject.ErrorBody as IDictionary;
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
        /// <param name="resultObject"></param>
        /// <param name="msg"></param>
        public static void ValidateFailed(this IResultObject resultObject, string msg)
        {
            resultObject.BuildResultObject(ResultObjectCodes.ValidateFailed, msg, null);
        }

        /// <summary>
        /// 服务异常
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="ex"></param>
        public static void ServerException(this IResultObject resultObject, Exception ex)
        {
            resultObject.BuildResultObject(ResultObjectCodes.ServerError, ex.Message);
        }

        /// <summary>
        /// 服务异常
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="msg"></param>
        public static void ServerException(this IResultObject resultObject, string msg)
        {
            resultObject.BuildResultObject(ResultObjectCodes.ServerError, msg);
        }

        /// <summary>
        /// 资源未找到
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="msg"></param>
        public static void NoFound(this IResultObject resultObject, string msg)
        {
            resultObject.BuildResultObject(ResultObjectCodes.NoFound, msg);
        }

        /// <summary>
        /// 操作被禁止
        /// </summary>
        /// <param name="resultObject"></param>
        /// <param name="msg"></param>
        public static void OperationForbidden(this IResultObject resultObject, string msg)
        {
            resultObject.BuildResultObject(ResultObjectCodes.OperationForbidden, msg);
        }
    }
}
