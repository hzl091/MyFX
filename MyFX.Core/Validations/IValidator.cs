/****************************************************************************************
 * 文件名：IValidator
 * 作者：huangzl
 * 创始时间：2017/10/12 15:37:50
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.Validations
{
    /// <summary>
    /// 实体验证接口
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="instance">被验证对象</param>
        /// <param name="throwError">是否抛出错误</param>
        /// <returns></returns>
        ValidateResults DoValidate(object instance, bool throwError = true);
    }
}
