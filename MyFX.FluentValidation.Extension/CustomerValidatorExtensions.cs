//=======================================================================================
/****************************************************************************************
 * 
 * 文件说明：
 * 作者：$兰支航$
 * 创始时间：2017/10/26 19:47:04
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFX.FluentValidation.Extension.ValidatorExtensions;

namespace FluentValidation /*与框架提供默认验证的命名空间一致,假装自己是正品*/
{
    public static class CustomerValidatorExtensions
    {
        /// <summary>
        /// 验证集合是否不为空[null与长度为0都认为是空]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, IEnumerable<TElement>> CollNotNull<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CollNotNullPropertyValidator<TElement>());
        }

        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> IsPhone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(@"^(\d{3}-\d{7,8}|\d{4}-\d{7,8}|1{1}\d{10})$");
        }

        /// <summary>
        ///  银行卡号验证[非0开头的8到27的字符串]
        ///  http://kf.qq.com/faq/140225MveaUz150819mYFjuE.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> IsBankCardNo<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(@"^(\d{5,30})$");
        }
    }
}
