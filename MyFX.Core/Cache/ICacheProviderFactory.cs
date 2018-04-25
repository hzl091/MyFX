using NFine.Code;

namespace MyFX.Core.Cache
{
    /// <summary>
    /// 缓存组件工厂
    /// </summary>
    public interface ICacheProviderFactory
    {
        /// <summary>
        /// 获取缓存组件
        /// </summary>
        /// <returns></returns>
        ICacheProvider GetCacheProvider();
    }
}
