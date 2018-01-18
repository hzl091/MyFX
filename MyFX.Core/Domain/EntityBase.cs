/****************************************************************************************
 * 文件名：EntityBase
 * 作者：黄泽林
 * 创始时间：2018/1/17 10:38:06
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TKey">标识</typeparam>
    public abstract class EntityBase<TKey>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}
