using System;
using System.Reflection;
using Autofac;

namespace MyFX.Core.DI
{
    /// <summary>
    /// 依赖注入引导程序
    /// </summary>
    public static class DIBootstrapper
    {
        private static DIContainer _container;
        private static readonly object _lockObj = new object();
        private static IContainer _autofaContainer;

        /// <summary>
        /// DI容器
        /// </summary>
        public static DIContainer Container
        {
            get
            {
                if (_container == null)
                { throw new Exception("请在程序入口调用DIBootstrapper.Initialise();启用DI容器"); }
                return _container;
            }
        }

        /// <summary>
        /// 初始化DI容器
        /// </summary>
        /// <returns></returns>
        /// <param name="assemblyStrings">注册程序集类型的名称</param>
        public static IContainer Initialize(params string[] assemblyStrings)
        {
            return Initialize(null, assemblyStrings);
        }

        /// <summary>
        /// 初始化DI容器
        /// </summary>
        /// <param name="register">需注册的组件:
        /// MVC写法:x=>x.RegisterControllers(Assembly.GetExecutingAssembly())</param>
        /// <param name="assemblyStrings">注册程序集类型的名称</param>
        /// <returns></returns>
        public static IContainer Initialize(Action<ContainerBuilder> register, params string[] assemblyStrings)
        {
            Func<IContainer> buildContainerAct = () =>
            {
                var length = assemblyStrings.Length;
                Assembly[] assemblies = new Assembly[length];
                for (int i = 0; i < length; i++)
                {
                    assemblies[i] = Assembly.Load(assemblyStrings[i]);
                }
                return BuildContainer(register, assemblies);
            };

           return BuildGlobalContainer(buildContainerAct);
        }

        /// <summary>
        /// 初始化DI容器
        /// </summary>
        /// <param name="assemblies">注册程序集类型</param>
        public static IContainer Initialize(params Assembly[] assemblies)
        {
            return BuildGlobalContainer(() => BuildContainer(null, assemblies));
        }
        /// <summary>
        /// 初始化DI容器
        /// </summary> 
        /// <param name="register">需注册的组件:
        /// MVC写法:x=>x.RegisterControllers(Assembly.GetExecutingAssembly())</param>
        /// <param name="assemblies">注册程序集类型</param>
        public static IContainer Initialize(Action<ContainerBuilder> register, params Assembly[] assemblies)
        {
            return BuildGlobalContainer(() => BuildContainer(register, assemblies));
        }

        /// <summary>
        /// 容器构建
        /// </summary> 
        /// <param name="register">需注册的组件:
        /// MVC写法:x=>x.RegisterControllers(Assembly.GetExecutingAssembly())</param>
        /// <param name="assemblies">注册程序集类型</param>
        private static IContainer BuildContainer(Action<ContainerBuilder> register, params Assembly[] assemblies)
        {
            var builder = new ContainerBuilder();
            Type baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证对象生命周期基于请求
            if (register != null)
            {
                register(builder);
            }

            _autofaContainer = builder.Build();
            _container = new DIContainer(_autofaContainer);
            return _autofaContainer;
        }

        /// <summary>
        /// 构建单例的全局容器对象
        /// </summary>
        /// <param name="buildContainerAct"></param>
        /// <returns></returns>
        private static IContainer BuildGlobalContainer(Func<IContainer> buildContainerAct)
        {
            if (_container == null)
            {
                lock (_lockObj)
                {
                    if (_container == null)
                    {
                       return buildContainerAct();
                    }
                }
            }

            return _autofaContainer; ;
        }
    }
}
