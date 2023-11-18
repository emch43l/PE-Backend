namespace Domain.Common.Identity;

public interface IUidIdentity<TKey> : IIdentity<TKey> where TKey: IEquatable<TKey>
{
    public Guid Guid { get; set; }
}