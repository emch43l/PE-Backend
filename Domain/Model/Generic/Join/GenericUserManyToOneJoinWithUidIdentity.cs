using Domain.Model.Generic.Base;
using Domain.Model.Generic.Interface;

namespace Domain.Model.Generic.Join;

public class GenericUserManyToOneJoinWithUidIdentity<TKey> : UidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public IGenericUser<TKey> GenericUser { get; set; }
    
    public TKey UserId { get; set; }

    public GenericUserManyToOneJoinWithUidIdentity() : base()
    {
        
    }
}