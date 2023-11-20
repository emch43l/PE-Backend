using ApplicationCore.Common.Implementation.EntityImplementation;
using Domain.Common.Repository;

namespace ApplicationCore.Common.Implementation.RepositoryImplementation;

public interface ICommentRepository : ICommentRepository<int,CommentEntity>
{
    
}