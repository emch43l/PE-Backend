using Domain.Common.Identity;

namespace Domain.Model.Interface;

public interface IUser<TKey> : IUidIdentity<TKey> where TKey: IEquatable<TKey>
{
    TKey Id { get; set; }
    
    
}