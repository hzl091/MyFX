using MyFX.Core.DI;

namespace MyFX.Core.Repository
{
    /// <summary>
    /// 工作单元工厂
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
