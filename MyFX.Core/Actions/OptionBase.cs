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
    /// <typeparam name="TResponse">响应类型</typeparam>
    public abstract class OptionBase<TRequest, TResponse>
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
        public TResponse Response { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="throwException">是否抛出异常</param>
        public abstract TResponse DoExecute(bool throwException = false);
    }
}
