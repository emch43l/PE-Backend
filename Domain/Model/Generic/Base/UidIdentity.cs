using Domain.Common.Identity;

namespace Domain.Model.Generic.Base;

public abstract class UidIdentity<TKey> : IUidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
    public Guid Guid { get; set; }

    public UidIdentity()
    {
        this.Guid = Guid.NewGuid();
    }
}