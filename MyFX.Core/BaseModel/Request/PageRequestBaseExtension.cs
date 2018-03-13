/****************************************************************************************
 * 文件名：PageRequestBaseExtension
 * 作者：huangzl
 * 创始时间：2018/3/13 17:53:43
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFX.Core.BaseModel.Paging;

namespace MyFX.Core.BaseModel.Request
{
    /// <summary>
    /// IRequest扩展
    /// </summary>
    public static class PageRequestBaseExtension
    {
        public static PagedQuery ToPagedQuery(this PageRequestBase request)
        {
            return new PagedQuery()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };
        }
    }
}
