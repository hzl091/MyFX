/****************************************************************************************
 * 文件名：PagedQuery
 * 作者：huangzl
 * 创始时间：2018/1/17 17:20:11
 * 创建说明：
****************************************************************************************/

using System;

namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 分页查询条件
    /// </summary>
    [Serializable]
    public class PagedQuery
    {
        public PagedQuery()
        {

        }

        public PagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页尺码
        /// </summary>
        public int PageSize { get; set; }
    }
}
