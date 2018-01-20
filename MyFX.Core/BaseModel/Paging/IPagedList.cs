using System.Collections.Generic;

namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 分页IList接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IPaged
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        IList<T> Rows { get; set; }
    }
}
