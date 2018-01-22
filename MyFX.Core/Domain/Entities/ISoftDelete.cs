namespace MyFX.Core.Domain.Entities
{
    /// <summary>
    /// 标识为软删除
    /// </summary>
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}