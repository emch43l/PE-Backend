using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ISpecificationHandler<Comment> _specificationHandler;
    private readonly IApplicationDbContext _context;

    public CommentRepository(ISpecificationHandler<Comment> specificationHandler, IApplicationDbContext context)
    {
        _specificationHandler = specificationHandler;
        _context = context;
    }
    
    public ISelectableQuery<Comment> GetPostCommentsQuery(Post post)
    {
        IQueryable<Comment> query = _context.Comments
            .Where(c => c.Post == post)
            .Include(c => c.User)
            .AsNoTracking();
        
        return SelectableQuery<Comment>.FromQuery(query);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<Comment?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Comment? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Comment> FindAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Comment o)
    {
        throw new NotImplementedException();
    }

    public bool RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(int id, Comment o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Comment> FindBySpecification(ISpecification<Comment>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Comment> GetQueryBySpecification(ISpecification<Comment>? specification = null)
    {
        return _specificationHandler.Handle(_context.Comments, specification);
    }

    public Task<Comment?> FindByGuidAsync(Guid id, bool ignoreQueryFilters = false)
    {
        throw new NotImplementedException();
    }

    public Comment? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Guid id, Comment o)
    {
        throw new NotImplementedException();
    }
}