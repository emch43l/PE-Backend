using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
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