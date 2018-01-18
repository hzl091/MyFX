/****************************************************************************************
 * 文件名：OrderRepository
 * 作者：黄泽林
 * 创始时间：2018/1/17 13:48:31
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Repository.Domain;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test
{
    public class RepositoryBase<TEntity,TKey> : Repository.Reps.EFRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        public RepositoryBase()
        {
        }
    }
}
