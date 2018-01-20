/****************************************************************************************
 * 文件名：PageRequestBase
 * 作者：huangzl
 * 创始时间：2018/1/20 13:57:54
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// 请求分类基类
    /// </summary>
    [Serializable]
    public class PageRequestBase : RequestBase
    {
        /// <summary>
        /// 当前页码数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
