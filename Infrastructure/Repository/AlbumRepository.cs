using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository;

public class AlbumRepository : IAlbumRepository
{
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

    public Album Add(Album o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Album o)
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