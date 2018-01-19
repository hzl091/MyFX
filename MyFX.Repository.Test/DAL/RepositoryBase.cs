/****************************************************************************************
 * 文件名：OrderRepository
 * 作者：黄泽林
 * 创始时间：2018/1/17 13:48:31
 * 创建说明：
****************************************************************************************/

using MyFX.Core.Domain;

namespace MyFX.Repository.Test.DAL
{
    public class RepositoryBase<TEntity,TKey> : EFRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        public RepositoryBase()
        {
        }
    }
}
