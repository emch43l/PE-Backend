using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Model;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public class CommentReactionRepository : EntityRepositoryBase<CommentReaction>, ICommentReactionRepository
{
    public CommentReactionRepository(IApplicationDbContext context) : base(context)
    {
    }
}