namespace MyFX.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元工厂
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
