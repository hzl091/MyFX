/****************************************************************************************
 * 文件名：EFUnitOfWork
 * 作者：huangzl
 * 创始时间：2018/1/18 10:06:58
 * 创建说明：
****************************************************************************************/

using System;
using System.Data.Entity;
using MyFX.Core.Repository;

namespace MyFX.Repository
{
    /// <summary>
    /// 基于EF的工作单元
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext Context { get; private set; }

        public EFUnitOfWork(DbContext context)
        {
            Context = context;
            context.Configuration.LazyLoadingEnabled = true;//默认启用数据懒加载
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
