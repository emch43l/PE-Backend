using Domain.Model.Base;
using Domain.Model.Interface;

namespace Domain.Model.Join;

public class UserManyToOneJoinWithUidIdentity<T> : UidIdentity<T> where T : IEquatable<T>
{
    public IUser<int> User { get; set; }
}