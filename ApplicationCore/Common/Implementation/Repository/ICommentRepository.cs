using ApplicationCore.Common.Implementation.Entity;
using Domain.Common.Repository;

namespace ApplicationCore.Common.Implementation.Repository;

public interface ICommentRepository : ICommentRepository<int,CommentEntity>
{
    
}