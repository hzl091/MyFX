/****************************************************************************************
 * 文件名：CacheManager
 * 作者：huangzl
 * 创始时间：2018/4/25 15:34:09
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.Cache
{
    public class CacheManager
    {
        static readonly ICacheProvider CacheProvider = null;

        static CacheManager()
        {
            ICacheProviderFactory fac = DI.DIBootstrapper.Container.Resolve<ICacheProviderFactory>();
            CacheProvider = fac == null ? new MemoryCacheProvider() : fac.GetCacheProvider();
        }

        /// <summary>
        /// 写入缓存（无过期时间）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Set<T>(string key, T value)
        {
            CacheProvider.Set<T>(key, value);
        }

        /// <summary>
        /// 写入缓存（有过期时间）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="exp">过期时间</param>
        public static void Set<T>(string key, T value, DateTime exp)
        {
            CacheProvider.Set<T>(key, value, exp);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static T Get<T>(string key)
        {
            return CacheProvider.Get<T>(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        public static void Remove(string key)
        {
            CacheProvider.Remove(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="keys">缓存键集</param>
        public static void RemoveRange(IEnumerable<string> keys)
        {
            CacheProvider.RemoveRange(keys);
        }

        /// <summary>
        /// 是否存在缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在</returns>
        public static bool Exists(string key)
        {
            return CacheProvider.Exists(key);
        }
    }
}
