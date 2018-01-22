/****************************************************************************************
 * 文件名：FindOrdersRequest
 * 作者：huangzl
 * 创始时间：2018/1/20 15:31:42
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
    public class FindOrdersRequest : IRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
