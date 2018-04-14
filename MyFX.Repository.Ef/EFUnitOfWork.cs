/****************************************************************************************
 * 文件名：EFUnitOfWork
 * 作者：huangzl
 * 创始时间：2018/1/18 10:06:58
 * 创建说明：
****************************************************************************************/

using System;
using System.Data.Entity;
using MyFX.Core.Domain.Uow;

namespace MyFX.Repository.Ef
{
    /// <summary>
    /// 基于EF的工作单元
    /// </summary>
    public abstract class EFUnitOfWork : IUnitOfWork, IDisposable
    {    
        public abstract DbContext Context { get; set; }

        public virtual void Commit()
        {
            if (Context == null)
            {
                throw new InvalidOperationException("DbContext未初始化");
            }
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
