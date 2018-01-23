/****************************************************************************************
 * 文件名：FindOrdersValidator
 * 作者：huangzl
 * 创始时间：2018/1/23 15:50:48
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyFX.Repository.Test.Dtos.Request;

namespace MyFX.Repository.Test.Service.Validators
{
    public class FindOrdersValidator : EntityValidatorBase<FindOrdersRequest>
    {
        public override void SetValidateRules()
        {
            RuleFor(o => o.PageSize).GreaterThan(0);
            RuleFor(o => o.PageIndex).GreaterThan(0);
        }
    }
}
