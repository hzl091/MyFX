/****************************************************************************************
 * 文件名：DbContextBase
 * 作者：huangzl
 * 创始时间：2018/1/22 10:39:12
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Result;
using MyFX.Core.Domain.Entities;
using MyFX.Core.Domain.Entities.Filters;
using MyFX.Core.Exceptions;
using MyFX.Repository.Ef.EntityFramework.DynamicFilters;

namespace MyFX.Repository.Ef
{
    public class DbContextBase : DbContext
    {
        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter<ISoftDelete, bool>(FiltersEnum.SoftDelete.ToString(), entity => entity.IsDeleted, false);
        }

        /// <summary>
        /// 保存更改前操作
        /// </summary>
        protected virtual void SaveChangesBefore()
        {

        }

        public sealed override int SaveChanges()
        {
            SaveChangesBefore();
            var result = 0;
            try
            {
               result = base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new RepositoryException("当前数据已被修改,请刷新后重试", ResultObjectCodes.DbUpdateConcurrency, ex);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                    {
                        string msg = string.Format("{0}属性验证失败:{1}", error.PropertyName, error.ErrorMessage);
                        throw new RepositoryException("msg", ResultObjectCodes.ValidateFailed, ex);
                    }
                }
            }
            return SaveChangesAfter(result);
        }

        /// <summary>
        /// 保存更改后操作
        /// </summary>
        /// <param name="result">影响的行数</param>
        protected virtual int SaveChangesAfter(int result)
        {
            return result;
        }
    }
}
