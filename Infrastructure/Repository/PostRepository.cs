using Domain.Common.Repository.PostRepository;
using Domain.Common.Specification;
using Domain.Model;
using Infrastructure.DB;

namespace Infrastructure.Repository;

public class PostRepository : IPostRepository<int>
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<PostEntity<int>?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostEntity<int>>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public PostEntity<int>? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<PostEntity<int>> FindAll()
    {
        throw new NotImplementedException();
    }

    public PostEntity<int> Add(PostEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, PostEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PostEntity<int>> FindBySpecification(ISpecification<PostEntity<int>>? specification = null)
    {
        throw new NotImplementedException();
    }

    public Task<PostEntity<int>?> FindByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public PostEntity<int>? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, PostEntity<int> o)
    {
        throw new NotImplementedException();
    }
}