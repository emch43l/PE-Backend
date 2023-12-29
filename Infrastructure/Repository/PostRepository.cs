using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PostRepository : IPostRepository
{
    private readonly ISpecificationHandler<Post> _specificationHandler;
    private readonly IApplicationDbContext _context;

    public PostRepository(IApplicationDbContext context, ISpecificationHandler<Post> specificationHandler)
    {
        _context = context;
        _specificationHandler = specificationHandler;
    }

    public ISelectableQuery<Post> GetPostWithCommentsQuery(Guid guid, int commentCount)
    {
        IQueryable<Post> query = _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(commentCount))
            .ThenInclude(c => c.User)
            .Where(p => p.Guid == guid)
            .AsNoTracking();
        
        return SelectableQuery<Post>.FromQuery(query);
    }

    public ISelectableQuery<Post> GetPostsWithUserAndFirstCommentQuery()
    {
        IQueryable<Post> query = _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(1))
            .ThenInclude(p => p.User)
            .AsNoTracking();
        
        return SelectableQuery<Post>.FromQuery(query);
    }
    
    public async Task<Post?> FindByGuidAsync(Guid id)
    {
        return await _context.Posts.Where(post => post.Guid == id).FirstOrDefaultAsync();
    }
    
    public Task<Post?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Post>> FindAllAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public Post? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Post> FindAll()
    {
        throw new NotImplementedException();
    }

    public Post Add(Post o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Post o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Post> FindBySpecification(ISpecification<Post>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Post> GetQueryBySpecification()
    {
        return _context.Posts;
    }

    public IQueryable<Post> GetQueryBySpecification(ISpecification<Post>? specification = null)
    {
        return _specificationHandler.Handle(_context.Posts,specification);
    }

    public Post? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, Post o)
    {
        throw new NotImplementedException();
    }
    
}