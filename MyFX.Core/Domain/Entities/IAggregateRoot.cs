namespace MyFX.Core.Domain.Entities
{
    public interface IAggregateRoot<TKey>
    {
        TKey Id { get; set; }
    }
}
