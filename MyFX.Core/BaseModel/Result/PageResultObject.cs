/****************************************************************************************
 * 文件名：PageResultObject
 * 作者：huangzl
 * 创始时间：2018/3/13 10:04:57
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFX.Core.BaseModel.Result
{
    /// <summary>
    /// 支持分页的结果对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResultObject<T> : ListResultObject<T>
    {
        public PageResultObject() 
            : base() { }

        public PageResultObject(int pageIndex, int totalCount, int pageSize)
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
        public long PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
            set { }
        }
    }
}
