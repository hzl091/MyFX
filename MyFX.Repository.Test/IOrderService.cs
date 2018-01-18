/****************************************************************************************
 * 文件名：IOrderService
 * 作者：黄泽林
 * 创始时间：2018/1/18 17:30:43
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.DI;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test
{
    public interface IOrderService : IDependency
    {
        void CreateOrder(Order order);
    }
}
