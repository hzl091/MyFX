using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core;

namespace MyFX.Repository.Test.DAL
{
    public static class EFDbContextFactory
    {
        /// <summary>
        /// 获取当前调用上下文的<see cref="EFDbContext"/>实例，可写可读。
        /// </summary>
        /// <returns></returns>
        public static DbContext GetDbContext()
        {
            //const string dbContextName = "OMSDbMaster";
            const string dbContextName = "OracleDbContext";
            OracleDbContext dbContext = InvokeContext.Get<OracleDbContext>(dbContextName);
            if (dbContext == null)
            {
                dbContext = new OracleDbContext(dbContextName);
                InvokeContext.Add<OracleDbContext>(dbContextName, dbContext);
            }

            dbContext.Database.Log = Console.WriteLine; //日志监控设置
            return dbContext;
        }

        /// <summary>
        /// 获取当前调用上下文的<see cref="EFDbContext"/>只读实例。
        /// </summary>
        /// <returns></returns>
        internal static DbContext GetReadonlyDbContext()
        {
            //const string dbContextName = "OMSDbSlave";
            const string dbContextName = "OracleDbContext";
            OracleDbContext dbContext = InvokeContext.Get<OracleDbContext>(dbContextName);
            if (dbContext == null)
            {
                dbContext = new OracleDbContext(dbContextName);
                InvokeContext.Add<OracleDbContext>(dbContextName, dbContext);
            }

            return dbContext;
        }

        public static DbContext GetSqlServerDbContext()
        {
            const string dbContextName = "MyFx";
            SqlServerDbContext dbContext = InvokeContext.Get<SqlServerDbContext>(dbContextName);
            if (dbContext == null)
            {
                dbContext = new SqlServerDbContext(dbContextName);
                InvokeContext.Add<SqlServerDbContext>(dbContextName, dbContext);
            }

            dbContext.Database.Log = Console.WriteLine; //日志监控设置
            return dbContext;
        }
    }
}
