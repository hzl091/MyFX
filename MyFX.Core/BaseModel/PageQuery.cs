/****************************************************************************************
 * 文件名：PageQuery
 * 作者：黄泽林
 * 创始时间：2018/1/17 17:20:11
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// 分页查询条件
    /// </summary>
    public class PageQuery
    {
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
