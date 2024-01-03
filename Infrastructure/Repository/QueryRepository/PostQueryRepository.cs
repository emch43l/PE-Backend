using ApplicationCore.Common.Extension;
using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Enum;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.QueryRepository;

public class PostQueryRepository : PostRepository, IPostQueryRepository
{
    public PostQueryRepository(IApplicationDbContext context) : base(context)
    {
        
    }
    
    public IQueryManager<Post> GetUserPostsWithCommentsQuery(IUser user, int commentCount)
    {
        IQueryable<Post> query = Context.Posts
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(commentCount))
            .ThenInclude(c => c.User)
            .Where(p => p.User == user)
            .IgnoreQueryFilters()
            .AsNoTracking();

        return QueryManager<Post>.FromQuery(query);
    }

    public IQueryManager<Post> GetPostWithCommentsQuery(Guid guid, int commentCount)
    {
        IQueryable<Post> query = Context.Posts
            .AsSplitQuery()
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(commentCount))
            .ThenInclude(c => c.User)
            .Where(p => p.Guid == guid)
            .AsNoTracking();
        
        return QueryManager<Post>.FromQuery(query);
    }

    public IQueryManager<Post> GetPublicPostsWithUserAndFirstCommentQuery()
    {
        IQueryable<Post> query = Context.Posts
            .Where(p => p.Status == StatusEnum.Visible)
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(1))
            .ThenInclude(p => p.User)
            .AsNoTracking();
        
        return QueryManager<Post>.FromQuery(query);
    }
    
    public IQueryManager<Post> GetQueryBySpecification(ISpecification<Post>? specification = null)
    {
        return QueryManager<Post>.FromQuery(Context.Posts.ApplySpecification(specification));
    }
    
}