using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyFX.Repository.BaseModel;
using MyFX.Repository.Domain;
using MyFX.Core.DI;

namespace MyFX.Repository.Reps
{
    /// <summary>
    /// 仓储接口定义
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">实体标识</typeparam>
    public interface IRepository<TEntity, in TKey> : IDependency 
        where TEntity : IAggregateRoot<TKey>
    {
        /// <summary>
        /// 按主键查询实体对象
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns></returns>
        TEntity GetByKey(TKey id);

        /// <summary>
        /// 查询单个实体对象
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        TEntity Single(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 查询第一个实体对象
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        TEntity First(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 获取实体对象集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll();

        /// <summary>
        /// 支持单个排序条件的实体对象集合查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> @where,
            Expression<Func<TEntity, object>> orderBy = null, bool isAsc = true);

        /// <summary>
        /// 支持多个排序条件的实体对象集合查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="sortRules">排序规则</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where, params SortRule[] sortRules);

        /// <summary>
        /// 支持单个排序条件分页的实体对象集合查询
        /// </summary>
        /// <param name="pageQuery"></param>
        /// <param name="totalRecord"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IEnumerable<TEntity> FindPageList(PageQuery pageQuery, out int totalRecord,
            Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, object>> orderBy,
            bool isAsc = true);

        /// <summary>
        /// 支持多个排序条件分页的实体对象集合查询
        /// </summary>
        /// <param name="pageQuery"></param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="where">条件</param>
        /// <param name="sortRules">排序规则</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindPageList(PageQuery pageQuery, out int totalRecord, Expression<Func<TEntity, bool>> where, SortRule[] sortRules);

        /// <summary>
        /// 判断实体对象是否存在
        /// </summary>
        /// <param name="where">条件</param>
        bool Exists(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="entity">实体</param>
        void Add(TEntity entity);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="id">实体标识</param>
        void Delete(TKey id);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 保存变更
        /// </summary>
        void Save();
    }
}
