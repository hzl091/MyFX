using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using MyFX.Core.DI;
using MyFX.Core.Domain.Uow;
using MyFX.Core.Logs;
using MyFX.Log.Log4Net;

namespace MyFX.WebApi.Test
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Action<ContainerBuilder> act = builder =>
            {
                builder.RegisterType<LogFactory>().As<ILogFactory>(); //配置使用的日志工厂
            };

            var container = DIBootstrapper.Initialize(act, "MyFx.Log.Log4Net");
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
