/****************************************************************************************
 * 文件名：EntityValidatorBase
 * 作者：huangzl
 * 创始时间：2017/10/12 14:58:19
 * 创建说明：
****************************************************************************************/

using System;
using System.Linq;
using FluentValidation;
using MyFX.Core.Validations;

//对FluentValidation做扩展
namespace FluentValidation
{
    /// <summary>
    /// 实体对象验证基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityValidatorBase<TEntity> : AbstractValidator<TEntity>, MyFX.Core.Validations.IValidator
    {
        public virtual ValidateResults DoValidate(object instance, bool throwError = true)
        {
            SetValidateRules();
            var rs = this.Validate((TEntity)instance);
            
            ValidateResults newRs = new ValidateResults();
            if (!rs.IsValid)
            {
                if (throwError)
                {
                    throw new ValidationException(rs.Errors.First().ErrorMessage);
                }
                newRs.AddRange(rs.Errors.Select(item => new ValidateResult { Key = item.PropertyName, ErrorMessage = item.ErrorMessage }));
            }
            this.AddCustomerValidate(newRs); //钩子,自定义验证时重写该方法 
            IsValid = newRs.IsValid;
            return newRs;
        }

        /// <summary>
        /// 验证状态
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 设置验证规则
        /// </summary>
        public abstract void SetValidateRules();

        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="validateResults"></param>
        protected virtual void AddCustomerValidate(ValidateResults validateResults)
        {
            
        }
    }
}
