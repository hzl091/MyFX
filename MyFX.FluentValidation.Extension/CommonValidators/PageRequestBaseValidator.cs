/****************************************************************************************
 * 文件名：PageRequestBaseValidator
 * 作者：huangzl
 * 创始时间：2018/3/13 17:59:43
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFX.Core.BaseModel.Request;

namespace MyFX.FluentValidation.Extension.CommonValidators
{
    public class PageRequestBaseValidator : EntityValidatorBase<PageRequestBase>
    {
        public override void SetValidateRules()
        {
            RuleFor(o => o.PageSize).GreaterThan(0);
            RuleFor(o => o.PageIndex).GreaterThan(0);
        }
    }
}
