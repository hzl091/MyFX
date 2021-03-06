﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using MyFX.Core.Base;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Logs;

namespace MyFX.WebApi.Extension.Filters
{
    /// <summary>
    /// 捕获action异常，返回统一请求结果
    /// </summary>
    public class ActionExceptionAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                string mediaType = "application/json";
                ResultObject rs = new ResultObject();
                rs.ServerException("服务器内部错误");
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(rs.ToJsonString(), Encoding.UTF8, mediaType)
                };

                LoggerManager.ErrorLog.Error(actionExecutedContext.Exception.InnerException != null
                    ? string.Format("服务器内部错误:{0}", actionExecutedContext.Exception.InnerException)
                    : string.Format("服务器内部错误:{0}", actionExecutedContext.Exception));
            });
        }
    }
}
