using Domain.Common.Repository.AlbumRepository;
using Domain.Common.Specification;
using Domain.Model;

namespace Infrastructure.Repository;

public class AlbumRepository : IAlbumRepository<int>
{
    public Task<AlbumEntity<int>?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AlbumEntity<int>>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public AlbumEntity<int>? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AlbumEntity<int>> FindAll()
    {
        throw new NotImplementedException();
    }

    public AlbumEntity<int> Add(AlbumEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, AlbumEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AlbumEntity<int>> FindBySpecification(ISpecification<AlbumEntity<int>>? specification = null)
    {
        throw new NotImplementedException();
    }
}