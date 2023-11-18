namespace Domain.Common.Identity;

public interface IIdentity<TKey> : IEquatable<TKey> where TKey: IEquatable<TKey>
{
    public TKey Id { get; set; }

    bool IEquatable<TKey>.Equals(TKey? other)
    {
        return this.Equals(other);
    }
}