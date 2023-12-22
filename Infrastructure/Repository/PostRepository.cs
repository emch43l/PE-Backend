using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.Common.Interface;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PostRepository : IPostRepository
{
    private readonly ISpecificationHandler<PostEntity> _specificationHandler;
    private readonly IApplicationDbContext _context;

    public PostRepository(IApplicationDbContext context, ISpecificationHandler<PostEntity> specificationHandler)
    {
        _context = context;
        _specificationHandler = specificationHandler;
    }

    public Task<PostEntity?> GetPostWithComments(Guid guid, int commentCount)
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(commentCount))
            .ThenInclude(c => c.User)
            .Where(p => p.Guid == guid)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public IQueryable<PostEntity> GetPostsWithUserAndFirstCommentQuery()
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments.OrderBy(c => c.ReactionCount).Take(1))
            .ThenInclude(p => p.User)
            .AsNoTracking();
    }
    
    public Task<PostEntity?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PostEntity>> FindAllAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public PostEntity? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<PostEntity> FindAll()
    {
        throw new NotImplementedException();
    }

    public PostEntity Add(PostEntity o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, PostEntity o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PostEntity> FindBySpecification(ISpecification<PostEntity>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<PostEntity> GetQueryBySpecification()
    {
        return _context.Posts;
    }

    public IQueryable<PostEntity> GetQueryBySpecification(ISpecification<PostEntity>? specification = null)
    {
        return _specificationHandler.Handle(_context.Posts,specification);
    }

    public async Task<PostEntity?> FindByGuidAsync(Guid id)
    {
        return await _context.Posts.Where(post => post.Guid == id).FirstOrDefaultAsync();
    }

    public PostEntity? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, PostEntity o)
    {
        throw new NotImplementedException();
    }
    
}