using ApplicationCore.Common.Implementation.EntityImplementation;
using Domain.Common.Repository;
using Domain.Model.Generic;

namespace ApplicationCore.Common.Implementation.RepositoryImplementation;

public interface IPostRepository : IPostRepository<int,PostEntity>
{
    
}