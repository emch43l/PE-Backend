using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository;

public class AlbumRepository : IAlbumRepository
{
    private readonly IApplicationDbContext _context;

    public AlbumRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<Album?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Album>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Album? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Album> FindAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Album o)
    {
        throw new NotImplementedException();
    }

    public bool RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(int id, Album o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Album> FindBySpecification(ISpecification<Album>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Album> GetQuery()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Album> GetQueryBySpecification(ISpecification<Album>? specification = null)
    {
        throw new NotImplementedException();
    }
}