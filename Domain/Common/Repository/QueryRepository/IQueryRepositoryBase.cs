using Domain.Common.Query;
using Domain.Common.Specification;
using Domain.Model;
using Domain.Model.Interface;

namespace Domain.Common.Repository.QueryRepository;

public interface IQueryRepositoryBase<T> where T: IEntity
{
    IQueryManager<T> GetQueryBySpecification(ISpecification<T> specification);
}