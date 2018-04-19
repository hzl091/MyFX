using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin.Security.OAuth;
using MyFX.WebApi.Extension;
using MyFX.WebApi.Extension.Filters;
using Newtonsoft.Json.Serialization;

namespace MyFX.WebApi.Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 签名验证BasicAuthFilter
            //config.Filters.Add(new SignatureAttribute());
            // 截获并处理Action执行过程中发生的异常
            config.Filters.Add(new ActionExceptionAttribute());
            // 截获并处理Action执行过程之外发生的异常
            config.Services.Replace(typeof(IExceptionHandler), new UnhandledExceptionHandler());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                 name: "OrderApi",
                 routeTemplate: "salesapi/{controller}/{orderno}",
                 defaults: new { orderno = RouteParameter.Optional }
             );
        }
    }
}
