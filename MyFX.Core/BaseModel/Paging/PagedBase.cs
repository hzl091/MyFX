using System;
using System.Runtime.Serialization;

namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 分页模型基类
    /// </summary>
    [DataContract]
    public class PagedBase : IPaged
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PagedBase()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pagedQuery">分页查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public PagedBase(PagedQuery pagedQuery, int totalCount)
            : this(pagedQuery.PageIndex, pagedQuery.PageSize, totalCount)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pageIndex">当前页码数</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalCount">总记录数</param>
        public PagedBase(int pageIndex, int pageSize, int totalCount)
        {
            if (pageSize <= 0)
            {
                throw new Exception("pageSize必须大于0");
            }
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.TotalCount = totalCount;
        }

        /// <summary>
        /// 当前页码数
        /// </summary>
        [DataMember]
        public virtual int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        [DataMember]
        public virtual int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public virtual int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public virtual int PageCount
        {
            get { return (int) Math.Ceiling((double) this.TotalCount/this.PageSize); }
            set { } //wcf序列化或者反射的时候需要
        }
    }
}