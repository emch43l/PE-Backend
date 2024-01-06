using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Model;

namespace Infrastructure.Repository.QueryRepository;

public class CommentReactionQueryRepository : CommentReactionRepository, ICommentReactionQueryRepository
{
    public CommentReactionQueryRepository(IApplicationDbContext context) : base(context)
    {
    }

    public IQueryManager<CommentReaction> GetQueryBySpecification(ISpecification<CommentReaction> specification)
    {
        return QueryManager<CommentReaction>.FromQuery(Context.CommentReactions).ApplySpecification(specification);
    }
}