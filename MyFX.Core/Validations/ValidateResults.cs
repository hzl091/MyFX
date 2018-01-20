/****************************************************************************************
 * 文件名：ValidateResults
 * 作者：huangzl
 * 创始时间：2017/5/18 17:23:56
 * 创建说明：
****************************************************************************************/

using System.Collections.Generic;

namespace MyFX.Core.Validations
{
    /// <summary>
    /// 验证结果集
    /// </summary>
    public class ValidateResults : List<ValidateResult>
    {
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Count == 0;
            }
        }

        public void AddResult(string key, string errorMessage)
        {
            this.Add(new ValidateResult(){ Key = key, ErrorMessage = errorMessage});
        }
    }
}
