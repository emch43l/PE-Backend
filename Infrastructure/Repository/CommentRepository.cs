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

    public Comment Add(Comment o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Comment o)
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

    public Task<Comment?> FindByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Comment? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, Comment o)
    {
        throw new NotImplementedException();
    }
}