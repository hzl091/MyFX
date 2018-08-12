﻿/****************************************************************************************
 * 文件名：AggregateRoot
 * 作者：huangzl
 * 创始时间：2018/1/17 10:35:53
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.Domain.Entities
{
   /// <summary>
   /// 聚合根对象(是一种特殊的实体)
   /// </summary>
   /// <typeparam name="TKey">标识</typeparam>
   public abstract class AggregateRoot<TKey> : EntityBase<TKey>, IAggregateRoot<TKey>
   {
   }
}
