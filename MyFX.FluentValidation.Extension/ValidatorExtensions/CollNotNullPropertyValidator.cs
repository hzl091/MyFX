//=======================================================================================
/****************************************************************************************
 * 
 * 文件说明：
 * 作者：$兰支航$
 * 创始时间：2017/10/26 19:59:18
 * 创建说明：
****************************************************************************************/

using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace MyFX.FluentValidation.Extension.ValidatorExtensions
{
    public class CollNotNullPropertyValidator<T> : PropertyValidator
    {
        public CollNotNullPropertyValidator()
            : base(string.Format("[{0}]集合不能为空", typeof(T).Name))
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IEnumerable<T>;
            return list != null && list.Any();
        }
    }
}
