using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 列表分页模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
   [DataContract]
    public class PagedList<T> : PagedBase, IPagedList<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PagedList()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">分页数据列表</param>
        /// <param name="pagedQuery">分页查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public PagedList(IEnumerable<T> rows, PagedQuery pagedQuery, int totalCount)
            : base(pagedQuery, totalCount)
        {
            this.Rows = rows.ToList();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rows">分页数据列表</param>
        /// <param name="pageIndex">当前页码数</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalCount">总记录数</param>
        public PagedList(IEnumerable<T> rows, int pageIndex, int pageSize, int totalCount)
            : base(pageIndex, pageSize, totalCount)
        {
            this.Rows = rows.ToList();
        }

        /// <summary>
        /// 分页数据列表
        /// </summary>
        [DataMember]
        public virtual IList<T> Rows { get; set; }
    }
}
