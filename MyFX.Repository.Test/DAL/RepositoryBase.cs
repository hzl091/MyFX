/****************************************************************************************
 * 文件名：OrderRepository
 * 作者：huangzl
 * 创始时间：2018/1/17 13:48:31
 * 创建说明：
****************************************************************************************/

using MyFX.Core.Domain;
using MyFX.Core.Domain.Entities;
using MyFX.Repository.Ef;

namespace MyFX.Repository.Test.DAL
{
    public abstract class RepositoryBase<TEntity,TKey> : EFRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        public RepositoryBase()
        {
        }
    }
}
