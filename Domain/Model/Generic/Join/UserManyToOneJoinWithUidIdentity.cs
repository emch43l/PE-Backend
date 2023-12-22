using Domain.Model.Generic.Base;

namespace Domain.Model.Generic.Join;

public class UserManyToOneJoinWithUidIdentity : UidIdentity<int>
{
    public IUser User { get; set; }
    
    public int UserId { get; set; }

    public UserManyToOneJoinWithUidIdentity() : base()
    {
        
    }
}