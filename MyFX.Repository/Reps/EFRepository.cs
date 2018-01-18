/****************************************************************************************
 * 文件名：EFRepository
 * 作者：黄泽林
 * 创始时间：2018/1/17 10:11:47
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyFX.Core.DI;
using MyFX.Repository.BaseModel;
using MyFX.Repository.Domain;

namespace MyFX.Repository.Reps
{
    public abstract class EFRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity 
        : EntityBase<TKey>, IAggregateRoot<TKey>
    {
        private DbContext _dbContext = null;
        private DbSet<TEntity> _dbSet = null;

        /// <summary>
        /// 工作单元
        /// </summary>
        /// <typeparam name="TUnitOfWork"></typeparam>
        /// <returns></returns>
        public TUnitOfWork GetCurrentUnitOfWork<TUnitOfWork>() where TUnitOfWork : IUnitOfWork
        {
            return (TUnitOfWork)UnitOfWork.Current;
        }

        /// <summary>
        /// DB上下文
        /// </summary>
        public DbContext DbContext 
        {
            get { return _dbContext ?? (_dbContext = GetCurrentUnitOfWork<EFUnitOfWork>().Context); }
        }

        /// <summary>
        /// 当前实体类型集合
        /// </summary>
        public DbSet<TEntity> Rs
        {
            get { return _dbSet ?? (_dbSet = this.DbContext.Set<TEntity>()); }
        }

        public TEntity GetByKey(TKey id)
        {
            if (id == null)
            {
                throw  new ArgumentNullException("id");
            }
            return Rs.FirstOrDefault(e => e.Id.Equals(id));
        }

        public TEntity Single(Expression<Func<TEntity, bool>> @where)
        {
            if (where == null)
            {
                throw new ArgumentNullException("where");
            }
            return Rs.Single(@where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> @where)
        {
            if (where == null)
            {
                throw new ArgumentNullException("where");
            }
            return Rs.FirstOrDefault(@where);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Rs.ToList();
        }

        /// <summary>
        /// 附加排序规则
        /// </summary>
        /// <param name="queryObj"></param>
        /// <param name="orderByExpression"></param>
        private IQueryable<TEntity> AttachSortRule(IQueryable<TEntity> queryObj, SortRule[] orderByExpression)
        {
            //创建表达式变量参数
            var parameter = Expression.Parameter(typeof(TEntity), "o");
            foreach (SortRule sortItem in orderByExpression)
            {
                //根据属性名获取属性
                var property = typeof(TEntity).GetProperty(sortItem.PropertyName);
                if (property == null)
                {
                    throw new Exception("PropertyName不存在");
                }
                //创建一个访问属性的表达式
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);

                string orderName = sortItem.IsDesc ? "OrderByDescending" : "OrderBy";
                MethodCallExpression resultExp = Expression.Call(typeof(Queryable), orderName,
                    new Type[] { typeof(TEntity), property.PropertyType }, queryObj.Expression,
                    Expression.Quote(orderByExp));
                queryObj = queryObj.Provider.CreateQuery<TEntity>(resultExp);
            }

            return queryObj;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, object>> orderBy = null, bool isAsc = true)
        {
            if (where == null)
            {
                throw new ArgumentNullException("where");
            }

            var queryObj = Rs.Where<TEntity>(@where);
            if (orderBy == null)
            {
                return queryObj.ToList();
            }

            return isAsc ? queryObj.OrderBy(orderBy).ToList()
                : queryObj.OrderByDescending(orderBy).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> @where, params SortRule[] sortRules)
        {
            if (where == null)
            {
                throw new ArgumentNullException("where");
            }

            var queryObj = Rs.Where<TEntity>(@where);
            if (sortRules == null || !sortRules.Any())
            {
                return queryObj.ToList();
            }

            queryObj = this.AttachSortRule(queryObj, sortRules);
            return queryObj.ToList();
        }

        public IEnumerable<TEntity> FindPageList(PageQuery pageQuery, out int totalRecord, Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, object>> orderBy,
            bool isAsc = true)
        {
            if (pageQuery == null)
            {
                throw new ArgumentNullException("pageQuery");
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException("orderBy");
            }

            IQueryable<TEntity> queryObj = Rs;
            if (where != null)
            {
                queryObj = queryObj.Where<TEntity>(@where);
            }

            queryObj = isAsc ? queryObj.OrderBy(orderBy)
                : queryObj.OrderByDescending(orderBy);
            totalRecord = queryObj.Count();//获取总记录数
            return queryObj.Skip((pageQuery.PageIndex - 1) * pageQuery.PageSize).Take(pageQuery.PageSize).ToList();//获取分页
        }

        public IEnumerable<TEntity> FindPageList(PageQuery pageQuery, out int totalRecord, Expression<Func<TEntity, bool>> @where, SortRule[] sortRules)
        {
            if (pageQuery == null)
            {
                throw new ArgumentNullException("pageQuery");
            }

            if (sortRules == null || !sortRules.Any())
            {
                throw new ArgumentNullException("sortRules");
            }

            IQueryable<TEntity> queryObj = Rs;
            if (where != null)
            {
                queryObj = queryObj.Where<TEntity>(@where);
            }

            queryObj = this.AttachSortRule(queryObj, sortRules);
            totalRecord = queryObj.Count();//获取总记录数
            return queryObj.Skip((pageQuery.PageIndex - 1) * pageQuery.PageSize).Take(pageQuery.PageSize).ToList();//获取分页
        }

        public bool Exists(Expression<Func<TEntity, bool>> @where)
        {
            return Rs.Where(where).Any();
        }

        public void Add(TEntity entity)
        {
           Rs.Add(entity);
        }

        public void Delete(TKey id)
        {
            var entity = GetByKey(id);
            if (entity == null)
            {
                throw new Exception(string.Format("id[{0}] not found", id));
            }
            Rs.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            Rs.Remove(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
