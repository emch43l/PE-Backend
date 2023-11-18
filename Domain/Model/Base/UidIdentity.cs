using Domain.Common.Identity;

namespace Domain.Model.Base;

public abstract class UidIdentity<T> : IUidIdentity<T> where T : IEquatable<T>
{
    public T Id { get; set; }
    public Guid Guid { get; set; }

    public UidIdentity()
    {
        this.Guid = new Guid();
    }
}