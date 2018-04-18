using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using MyFX.Core.Base;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Security;
using MyFX.WebApi.Extension.Config;

namespace MyFX.WebApi.Extension.Filters
{
    /// <summary>
    /// 签名认证
    /// </summary>
    public class SignatureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var headers = request.Headers;

            string appid = headers.Contains("appid") ? headers.GetValues("appid").FirstOrDefault() : "";
            string timestamp = headers.Contains("timestamp") ? headers.GetValues("timestamp").FirstOrDefault() : "";
            string nonce = headers.Contains("nonce") ? headers.GetValues("nonce").FirstOrDefault() : "";
            string signature = headers.Contains("signature") ? headers.GetValues("signature").FirstOrDefault() : "";

            var signatureHeader = new SignatureHeader(appid, timestamp, nonce, signature);
            string mediaType = "application/json";
            ResultObject rs = new ResultObject();
            //判断请求头
            if (!signatureHeader.Verify())
            {
                rs.OperationForUnauthorized("请求头信息不完整");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(rs.ToJsonString(), Encoding.UTF8, mediaType)
                };

                base.OnActionExecuting(actionContext);
                return;
            }

            //判断请求是否过期
            if (IsTimeout(signatureHeader.Timestamp))
            {
                rs.OperationForUnauthorized("请求已过期");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(rs.ToJsonString(), Encoding.UTF8, mediaType)
                };
                base.OnActionExecuting(actionContext);
                return;
            }

            //todo 秘钥需要动态处理
#if DEBUG
            var secret = "test";
#else
            // 根据SignatureHeader.AppId从配置或者数据库中取出对应的密钥
            var secret = "test";
#endif

            //根据请求类型拼接参数
            var method = request.Method.Method;
            NameValueCollection form = HttpContext.Current.Request.QueryString;
            string data = string.Empty;
            switch (method)
            {
                case "POST":
                case "PUT":
                    HttpContext.Current.Request.InputStream.Position = 0;
                    var stream = HttpContext.Current.Request.InputStream;
                    var byts = new byte[stream.Length];
                    HttpContext.Current.Request.InputStream.Read(byts, 0, byts.Length);
                    data = Encoding.UTF8.GetString(byts);
                    break;
                case "GET":
                case "DELETE":
                    data = GetSignQueryString(form);
                    break;
                default:
                    rs.OperationForUnauthorized(string.Format("不允许{0}请求", method));
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent(rs.ToJsonString(), Encoding.UTF8, mediaType)
                    };
                    base.OnActionExecuting(actionContext);
                    return;
            }
            // 签名数据（顺序：请求参数 -> 应用id -> 时间戳 -> 随机数）
            var signData = data + signatureHeader.ToString();
            if (!Signature.Verify(signData, secret, signatureHeader.Signature))
            {
                rs.OperationForUnauthorized("无效签名");
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(rs.ToJsonString(), Encoding.UTF8, mediaType)
                };
                base.OnActionExecuting(actionContext);
                return;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }

        /// <summary>
        /// 是否超时
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private bool IsTimeout(string timestamp)
        {
            var ts1 = 0d;
            if (!double.TryParse(timestamp, out ts1)) return true;

            var ts2 = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
            var ts = ts2 - ts1;

            return ts > AppSettings.RequestExpireTime * 1000d;
        }

        /// <summary>
        /// 拼接加密用的请求参数
        /// </summary>
        /// <param name="query">url参数。</param>
        /// <returns></returns>
        private string GetSignQueryString(NameValueCollection query)
        {
            // 按Key的字母顺序排序
            var sortedParams = GetSortedDictionary(query);
            var sb = new StringBuilder();
            // 把所有参数名和参数值串在一起
            foreach (var item in sortedParams)
            {
                sb.Append(item.Key).Append(item.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取排序的键值对
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private SortedDictionary<string, string> GetSortedDictionary(NameValueCollection nvc, Func<string, bool> filter = null)
        {
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            if (nvc != null && nvc.Count > 0)
            {
                foreach (var k in nvc.AllKeys)
                {
                    if (filter == null || !filter(k))
                    {//如果没设置过滤条件或者无需过滤  
                        dic.Add(k, nvc[k]);
                    }
                }
            }
            return dic;
        }
    }
}
