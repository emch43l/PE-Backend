using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Common.Implementation.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository;

public class AlbumRepository : IAlbumRepository
{
    public Task<AlbumEntity?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AlbumEntity>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public AlbumEntity? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AlbumEntity> FindAll()
    {
        throw new NotImplementedException();
    }

    public AlbumEntity Add(AlbumEntity o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, AlbumEntity o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AlbumEntity> FindBySpecification(ISpecification<AlbumEntity>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<AlbumEntity> GetQuery()
    {
        throw new NotImplementedException();
    }

    public IQueryable<AlbumEntity> GetQueryBySpecification(ISpecification<AlbumEntity>? specification = null)
    {
        throw new NotImplementedException();
    }
}