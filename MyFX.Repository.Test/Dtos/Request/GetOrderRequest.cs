/****************************************************************************************
 * 文件名：GetOrderRequest
 * 作者：huangzl
 * 创始时间：2018/1/20 15:15:29
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Request;

namespace MyFX.Repository.Test.Dtos.Request
{
    public class GetOrderRequest : RequestBase
    {
        public string OrderNo { get; set; }
    }
}
