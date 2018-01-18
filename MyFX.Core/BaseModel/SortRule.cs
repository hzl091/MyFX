/****************************************************************************************
 * 文件名：SortRule
 * 作者：黄泽林
 * 创始时间：2018/1/17 16:01:34
 * 创建说明：
****************************************************************************************/

namespace MyFX.Core.BaseModel
{
    /// <summary>
    /// 排序规则
    /// </summary>
    public class SortRule
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 降序排列
        /// </summary>
        public bool IsDesc { get; set; }
    }
}
