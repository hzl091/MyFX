﻿/****************************************************************************************
 * 文件名：OrderRepository
 * 作者：huangzl
 * 创始时间：2018/1/17 13:57:42
 * 创建说明：
****************************************************************************************/

using System;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.DAL
{
    public class OrderRepository : RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository()
        {
            Console.WriteLine("OrderRepository");
        }

        public override Order GetByKey(int id)
        {
            return this.Rs.Find(id);
        }
    }
}
