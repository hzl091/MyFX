/****************************************************************************************
 * 文件名：MemoryCacheProvider
 * 作者：huangzl
 * 创始时间：2018/4/25 15:03:51
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace MyFX.Core.Cache
{
    /// <summary>
    /// MemoryCache缓存提供者
    /// </summary>
    public class MemoryCacheProvider : ICacheProvider
    {
        /// <summary>
        /// 写入缓存（无过期时间）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Set<T>(string key, T value)
        {
            //如果缓存已存在则清空
            if (MemoryCache.Default.Get(key) != null)
            {
                MemoryCache.Default.Remove(key);
            }

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.NotRemovable;

            MemoryCache.Default.Set(key, value, policy);
        }

        /// <summary>
        /// 写入缓存（有过期时间）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="exp">过期时间</param>
        public void Set<T>(string key, T value, DateTime exp)
        {
            //如果缓存已存在则清空
            if (MemoryCache.Default.Get(key) != null)
            {
                MemoryCache.Default.Remove(key);
            }

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = exp;

            MemoryCache.Default.Set(key, value, policy);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public T Get<T>(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="keys">缓存键集</param>
        public void RemoveRange(IEnumerable<string> keys)
        {
            foreach (string key in keys)
            {
                this.Remove(key);
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="keyPattern">缓存键表达式</param>
        public void RemoveRange(string keyPattern)
        {
            IEnumerable<string> specKeys = this.GetKeys(keyPattern);

            this.RemoveRange(specKeys);
        }

        /// <summary>
        /// 是否存在缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>是否存在</returns>
        public bool Exists(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        /// <summary>
        /// 获取缓存键列表
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        /// <returns>缓存键列表</returns>
        public IEnumerable<string> GetKeys(string pattern)
        {
            IEnumerable<string> allKeys = MemoryCache.Default.ToArray().Select(x => x.Key);

            if (string.IsNullOrWhiteSpace(pattern))
            {
                return new string[0];
            }

            ICollection<string> specKeys = new HashSet<string>();

            foreach (string key in allKeys)
            {
                if (Regex.IsMatch(key, pattern))
                {
                    specKeys.Add(key);
                }
            }

            return specKeys;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {

        }
    }
}
