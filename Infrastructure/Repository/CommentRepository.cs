using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository;

public class CommentRepository : ICommentRepository
{
    public Task<CommentEntity?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentEntity>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public CommentEntity? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public List<CommentEntity> FindAll()
    {
        throw new NotImplementedException();
    }

    public CommentEntity Add(CommentEntity o)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, CommentEntity o)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CommentEntity> FindBySpecification(ISpecification<CommentEntity>? specification = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<CommentEntity> GetQuery()
    {
        throw new NotImplementedException();
    }

    public IQueryable<CommentEntity> GetQueryBySpecification(ISpecification<CommentEntity>? specification = null)
    {
        throw new NotImplementedException();
    }

    public Task<CommentEntity?> FindByGuidAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public CommentEntity? FindByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void RemoveByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, CommentEntity o)
    {
        throw new NotImplementedException();
    }
}