using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using MyFX.Core.Base;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Logs;

namespace MyFX.WebApi.Extension
{
    /// <summary>
    /// 捕获Unhandled返回统一请求结果
    /// </summary>
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
               string mediaType = "application/json";
                ResultObject rs = new ResultObject();
                rs.ServerException("服务器内部错误");
                context.Request.CreateResponse(HttpStatusCode.OK, rs.ToJsonString(), mediaType);

                LoggerManager.ErrorLog.Error(context.Exception.InnerException != null
                    ? string.Format("服务器内部错误:{0}", context.Exception.InnerException)
                    : string.Format("服务器内部错误:{0}", context.Exception));
            });
        }
    }
}
