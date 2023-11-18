using Domain.Common.Repository.CommentRepository;
using Domain.Common.Specification;
using Domain.Model;

namespace Infrastructure.Repository;

public class CommentRepository : ICommentRepository<int>
{
    public Task<CommentEntity<int>?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentEntity<int>>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public CommentEntity<int>? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<CommentEntity<int>> FindAll()
    {
        throw new NotImplementedException();
    }

    public CommentEntity<int> Add(CommentEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, CommentEntity<int> o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CommentEntity<int>> FindBySpecification(ISpecification<CommentEntity<int>>? specification = null)
    {
        throw new NotImplementedException();
    }

    public Task<CommentEntity<int>?> FindByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public CommentEntity<int>? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, CommentEntity<int> o)
    {
        throw new NotImplementedException();
    }
}