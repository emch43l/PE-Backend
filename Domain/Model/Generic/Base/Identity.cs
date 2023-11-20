using Domain.Common.Identity;

namespace Domain.Model.Generic.Base;

public abstract class Identity<TKey> : IIdentity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}