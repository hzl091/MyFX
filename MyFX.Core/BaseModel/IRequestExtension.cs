/****************************************************************************************
 * 文件名：RequestBaseExtension
 * 作者：huangzl
 * 创始时间：2017/5/23 17:23:43
 * 创建说明：
****************************************************************************************/

using System;
using System.Linq;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Validations;

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// IRequest扩展
    /// </summary>
    public static class IRequestExtension
    {
        /// <summary>
        /// 执行验证操作
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <param name="validator">验证器</param>
        /// <param name="throwError">是否抛出错误</param>
        public static ResultObject Validate(this IRequest request, IValidator validator, bool throwError = true)
        {
            if (validator == null) { throw new ArgumentNullException("validator"); }
            if (request == null) { throw new ArgumentNullException("request"); }
            var rs = validator.DoValidate(request, throwError);
            var resultObject = new ResultObject();
            if (!rs.IsValid)
            {
                resultObject.ValidateFailed(rs.First().ErrorMessage);
            }
            return resultObject;
        }
    }
}
