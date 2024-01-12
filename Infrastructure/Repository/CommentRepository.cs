using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Model;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public class CommentRepository : EntityRepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(IApplicationDbContext context) : base(context)
    {
        
    }

    
}