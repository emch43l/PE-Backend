using Domain.Model.Base;

namespace Domain.Model.Join;

public class UserManyToOneJoinWithUidIdentity : UidIdentity<int>
{
    public IUser User { get; set; }
    
    public int UserId { get; set; }

    public UserManyToOneJoinWithUidIdentity() : base()
    {
        
    }
}