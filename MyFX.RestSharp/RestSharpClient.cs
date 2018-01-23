/****************************************************************************************
 * 文件名：RestSharpClient
 * 作者：huangzl
 * 创始时间：2018/1/23 17:18:31
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace MyFX.RestSharp
{
    /// <summary>
    /// Rest接口执行者
    /// </summary>
    public class RestSharpClient : IRestSharp
    {
        /// <summary>
        /// 请求客户端
        /// </summary>
        private readonly RestClient _client;

        /// <summary>
        /// 接口基地址 格式：http://www.xxx.com/
        /// </summary>
        private string BaseUrl { get; set; }

        /// <summary>
        /// 默认的时间参数格式
        /// </summary>
        private string DefaultDateParameterFormat { get; set; }

        /// <summary>
        /// 默认验证器
        /// </summary>
        private IAuthenticator DefaultAuthenticator { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="authenticator"></param>
        public RestSharpClient(string baseUrl, IAuthenticator authenticator = null)
        {
            BaseUrl = baseUrl;
            _client = new RestClient(BaseUrl);
            DefaultAuthenticator = authenticator;

            //默认时间显示格式
            DefaultDateParameterFormat = "yyyy-MM-dd HH:mm:ss";

            //默认校验器
            if (DefaultAuthenticator != null)
            {
                _client.Authenticator = DefaultAuthenticator;
            }
        }

        /// <summary>
        /// 通用执行方法
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <remarks>
        /// 调用实例：
        /// var _client = new RestSharpClient("http://localhost:82/");
        /// var result = _client.Execute(new RestRequest("api/values", Method.GET));
        /// var content = result.Content;//返回的字符串数据
        /// </remarks>
        /// <returns></returns>
        public IRestResponse Execute(IRestRequest request)
        {
            request.DateFormat = string.IsNullOrEmpty(request.DateFormat)
                ? DefaultDateParameterFormat
                : request.DateFormat;
            var response = _client.Execute(request);
            return response;
        }

        /// <summary>
        /// 同步执行方法
        /// </summary>
        /// <typeparam name="T">返回的泛型对象</typeparam>
        /// <param name="request">请求参数</param>
        /// <remarks>
        ///  var _client = new RestSharpClient("http://localhost:82/");
        ///  var result = _client.Execute<List<string>>(new RestRequest("api/values", Method.GET)); 
        /// </remarks>
        /// <returns></returns>
        public T Execute<T>(IRestRequest request) where T : new()
        {
            request.DateFormat = string.IsNullOrEmpty(request.DateFormat)
                ? DefaultDateParameterFormat
                : request.DateFormat;
            var response = _client.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <remarks>
        /// 调用实例：
        /// var _client = new RestSharpClient("http://localhost:62981/");
        /// _client.ExecuteAsync<List<string>>(new RestRequest("api/values", Method.GET), result =>
        /// {
        ///      var content = result.Content;//返回的字符串数据
        /// });
        /// </remarks>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse> callback)
        {
            request.DateFormat = string.IsNullOrEmpty(request.DateFormat)
                ? DefaultDateParameterFormat
                : request.DateFormat;
            return _client.ExecuteAsync(request, callback);
        }

        /// <summary>
        /// 异步执行方法
        /// </summary>
        /// <typeparam name="T">返回的泛型对象</typeparam>
        /// <param name="request">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <remarks>
        /// 调用实例：
        /// var _client = new RestSharpClient("http://localhost:62981/");
        /// _client.ExecuteAsync<List<string>>(new RestRequest("api/values", Method.GET), result =>
        /// {
        ///      if (result.StatusCode != HttpStatusCode.OK)
        ///      {
        ///         return;
        ///      }
        ///      var data = result.Data;//返回数据
        /// });
        /// </remarks>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>> callback)
            where T : new()
        {
            request.DateFormat = string.IsNullOrEmpty(request.DateFormat)
                ? DefaultDateParameterFormat
                : request.DateFormat;
            return _client.ExecuteAsync<T>(request, callback);
        }
    }

}
