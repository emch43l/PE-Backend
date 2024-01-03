using ApplicationCore.Common.Extension;
using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.QueryRepository;

public class CommentQueryRepository : CommentRepository, ICommentQueryRepository
{
    public CommentQueryRepository(IApplicationDbContext context) : base(context)
    {
    }
    
    public IQueryManager<Comment> GetPostCommentsQuery(Post post)
    {
        IQueryable<Comment> query = Context.Comments
            .Where(c => c.Post == post)
            .Include(c => c.User)
            .AsNoTracking();
        
        return QueryManager<Comment>.FromQuery(query);
    }

    public IQueryManager<Comment> GetCommentCommentsQuery(Comment comment)
    {
        IQueryable<Comment> query = Context.Comments
            .Include(c => c.User)
            .Where(c => c.Parent == comment);
        
        return QueryManager<Comment>.FromQuery(query);
    }

    public IQueryManager<Comment> GetQueryBySpecification(ISpecification<Comment>? specification = null)
    {
        return QueryManager<Comment>.FromQuery(Context.Comments.ApplySpecification(specification));
    }
}