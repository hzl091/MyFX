using System;
using System.Collections.Generic;

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// 响应基类
    /// </summary>
    public abstract class ResponseBase : IResponse
    {

    }

    /// <summary>
    /// 返回列表数据的响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListResponseBase<T> : ResponseBase
    {
        /// <summary>
        /// 数据对象列表
        /// </summary>
        public IList<T> List { get; set; }
    }

    /// <summary>
    /// 返回支持分页的列表数据响应基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResponseBase<T> : ListResponseBase<T>
    {
        public PageResponseBase() : base() { }
        public PageResponseBase(int pageIndex, int totalCount, int pageSize)
            : this()
        {
            this.PageIndex = pageIndex;
            this.TotalCount = totalCount;
            this.PageSize = pageSize;
        }
        /// <summary>
        /// 页码数
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long PageCount { get { return (int)Math.Ceiling((double)this.TotalCount / this.PageSize); } }
    }
}
