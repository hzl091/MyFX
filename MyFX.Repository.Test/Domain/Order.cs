/****************************************************************************************
 * 文件名：Order
 * 作者：huangzl
 * 创始时间：2018/1/17 10:17:58
 * 创建说明：
****************************************************************************************/

using System;
using MyFX.Core.Domain;

namespace MyFX.Repository.Test.Domain
{
    public class Order : AggregateRoot<int>
    {
        public string OrderNo { get; set; }

        public long StoreId { get; set; }

        /// <summary>
        /// 店主Id
        /// </summary>
        public long StoreOwnerId { get; set; }

        /// <summary>
        /// 买家Id
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
    }
}
