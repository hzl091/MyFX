using System;

namespace MyFX.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
