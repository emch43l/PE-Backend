using Domain.Common.Identity;

namespace Domain.Model;

public interface IEntity : IUidIdentity<int>
{
    
}