using ApplicationCore.Common.Implementation.Entity;
using Domain.Common.Repository;

namespace ApplicationCore.Common.Implementation.Repository;

public interface IPostRepository : IPostRepository<int,PostEntity>
{
    
}