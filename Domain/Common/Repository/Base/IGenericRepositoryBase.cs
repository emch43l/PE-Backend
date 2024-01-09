using Domain.Common.Query;
using Domain.Common.Specification;
using Domain.Model.Interface;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TKey') - covariance, contravariance
public interface IGenericRepositoryBase<T> where T: IEntity
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    
    Task<T?> FindByIdAsync(int id);
    
    Task<List<T>> FindAllAsync();
    
    Task AddAsync(T entity, bool save = true);

    Task Remove(T entity, bool save = true);
    
    Task UpdateAsync(T entity, bool save = true);
    
    Task<T?> FindBySpecificationAsync(ISpecification<T>? specification = null);
    
    Task<IEnumerable<T>> FindAllBySpecificationAsync(ISpecification<T>? specification = null);

    IQueryManager<T> GetQueryManager();

}