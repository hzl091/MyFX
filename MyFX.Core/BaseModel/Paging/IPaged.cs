namespace MyFX.Core.BaseModel.Paging
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPaged
    {
        /// <summary>
        /// 当前页码数
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount{ get; }
    }
}
