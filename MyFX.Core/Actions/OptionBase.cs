/****************************************************************************************
 * 文件名：OptionBase
 * 作者：huangzl
 * 创始时间：2017/10/24 14:37:02
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.Actions
{
    /// <summary>
    /// 操作基类
    /// </summary>
    /// <typeparam name="TRequest">请求类型</typeparam>
    /// <typeparam name="TResultObject">响应类型</typeparam>
    public abstract class OptionBase<TRequest, TResultObject>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request">请求对象</param>
        public OptionBase(TRequest request)
        {
            this.Request = request;
        }

        /// <summary>
        /// 请求对象
        /// </summary>
        public TRequest Request { get; set; }

        /// <summary>
        /// 响应对象
        /// </summary>
        public TResultObject ResultObject { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="throwException">发生错误时，是否以抛异常的方式提示调用者</param>
        public abstract TResultObject DoExecute(bool throwException = false);
    }
}
