using Domain.Model.Base;
using Domain.Model.Interface;

namespace Domain.Model.Join;

public class UserManyToOneJoinWithUidIdentity<TKey> : UidIdentity<TKey> where TKey : IEquatable<TKey>
{
    public IUser<TKey> User { get; set; }
    
    public TKey UserId { get; set; }

    public UserManyToOneJoinWithUidIdentity() : base()
    {
        
    }
}