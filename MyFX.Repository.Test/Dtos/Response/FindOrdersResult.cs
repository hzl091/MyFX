/****************************************************************************************
 * 文件名：FindOrdersResult
 * 作者：huangzl
 * 创始时间：2018/1/20 15:31:56
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Paging;
using MyFX.Core.BaseModel.Result;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.Dtos.Response
{
    public class FindOrdersResult : ResultObject<IPagedList<Order>>
    {
    }
}
