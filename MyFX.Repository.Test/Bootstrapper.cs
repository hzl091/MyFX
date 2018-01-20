/****************************************************************************************
 * 文件名：Bootstrapper
 * 作者：huangzl
 * 创始时间：2018/1/19 16:17:27
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyFX.Core.DI;
using MyFX.Core.Repository;
using MyFX.Repository.Test.DAL;

namespace MyFX.Repository.Test
{
    public class Bootstrapper
    {
        private static bool _isStart;
        private static object lockobj = new object();
        private static Bootstrapper _current = null;

        private Bootstrapper()
        {
        }

        private IContainer _container = null;

        public IContainer Container
        {
            get { return _container; }
        }

        public void Start()
        {
            if (!_isStart)
            {
                _container = InitContainer();
                _isStart = true;
            }  
        }

        public static Bootstrapper Current {
            get
            {
                lock (lockobj)
                {
                    if (_current == null) 
                    { 
                        _current = new Bootstrapper();
                    }
                }

                return _current;
            }
        }

        private IContainer InitContainer()
        {
            var dbContext = new OracleDbContext();//实例化数据库上下文
            dbContext.Database.Log = Console.WriteLine;//sql日志监控配置

            Action<ContainerBuilder> act = builder =>
            {
                builder.RegisterType<EFUnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            }; //配置使用的工作单元工厂
            var container = DIBootstrapper.Initialise(act, new string[] { "MyFX.Repository.Test" });
            EFUnitOfWorkFactory.SetObjectContext(() => dbContext);//数据库上下文与工作单元工厂关联
            return container;
        }
    }
}
