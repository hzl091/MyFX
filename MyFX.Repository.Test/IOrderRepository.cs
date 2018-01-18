using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.DI;
using MyFX.Repository.Reps;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test
{
    public interface IOrderRepository : IRepository<Order, int>, IDependency
    {
    }
}
