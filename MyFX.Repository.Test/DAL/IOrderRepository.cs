using MyFX.Core.DI;
using MyFX.Core.Domain.Repositories;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.DAL
{
    public interface IOrderRepository : IRepository<Order, int>, IDependency
    {
    }
}
