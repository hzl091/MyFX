/****************************************************************************************
 * 文件名：EFUnitOfWorkFactory
 * 作者：黄泽林
 * 创始时间：2018/1/18 10:21:12
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Repository.Reps
{
    /// <summary>
    /// EF工作单元工厂
    /// </summary>
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static Func<DbContext> _dbContextDelegate;
        private static readonly Object _lockObject = new object();

        public static void SetObjectContext(Func<DbContext> dbContextDelegate)
        {
            _dbContextDelegate = dbContextDelegate;
        }

        public IUnitOfWork Create()
        {
            DbContext context;

            lock (_lockObject)
            {
                context = _dbContextDelegate();
            }

            return new EFUnitOfWork(context);
        }
    }
}
