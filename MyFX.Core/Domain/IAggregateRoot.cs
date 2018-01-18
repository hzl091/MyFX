namespace MyFX.Core.Domain
{
    public interface IAggregateRoot<TKey>
    {
        TKey Id { get; set; }
        int Version { get; set; }
    }
}
