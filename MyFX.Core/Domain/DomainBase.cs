/****************************************************************************************
 * 文件名：DomainBase
 * 作者：黄泽林
 * 创始时间：2017/10/12 17:47:54
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using MyFX.Core.Validations;

namespace MyFX.Core.Domain
{
    /// <summary>
    /// 领域基类
    /// </summary>
    public abstract class DomainBase
    {
        /// <summary>
        /// 执行验证操作
        /// </summary>
        /// <param name="validator">验证器</param>
        /// <param name="throwError">是否抛出错误</param>
        public ValidateResults Validate(IValidator validator, bool throwError = true)
        {
            if (validator == null) { throw new ArgumentNullException("validator"); }
            return this.Validate(new IValidator[] { validator }, throwError);
        }

        /// <summary>
        /// 执行验证操作 
        /// </summary>
        /// <param name="validators">验证器集合</param>
        /// <param name="throwError">是否抛出错误</param>
        public ValidateResults Validate(IEnumerable<IValidator> validators, bool throwError = true)
        {
            ValidateResults rs = new ValidateResults();
            if (validators == null) { throw new ArgumentNullException("validators"); }
           
            foreach (var validator in validators)
            {
                rs.AddRange(validator.DoValidate(this, throwError));
            }
            return rs;
        }
    }
}
