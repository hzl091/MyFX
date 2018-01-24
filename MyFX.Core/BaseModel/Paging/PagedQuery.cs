/****************************************************************************************
 * 文件名：PagedQuery
 * 作者：huangzl
 * 创始时间：2018/1/17 17:20:11
 * 创建说明：
****************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 分页查询条件
    /// </summary>
    [DataContract]
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
        [DataMember]
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 页尺码
        /// </summary>
        [DataMember]
        public virtual int PageSize { get; set; }
    }
}
