using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.DI;

namespace MyFX.Repository.Reps
{
    /// <summary>
    /// 工作单元工厂
    /// </summary>
    public interface IUnitOfWorkFactory : IDependency
    {
        IUnitOfWork Create();
    }
}
