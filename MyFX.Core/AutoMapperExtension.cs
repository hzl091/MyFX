using System.Collections.Generic;
using AutoMapper;

namespace MyFX.Core
{
    /// <summary>
    /// AutoMapper扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        ///  单个对象映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Initialize(c => c.CreateMap(obj.GetType(), typeof(T)));
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
            return Mapper.Map<List<TDestination>>(source);
        }
    }
}
