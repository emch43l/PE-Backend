using Domain.Common.Identity;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TKey') - covariance, contravariance
public interface IGenericRepositoryBase<T> where T: IUidIdentity<int>
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    
    Task<T?> FindByIdAsync(int id);
    
    Task<List<T>> FindAllAsync();
    
    Task AddAsync(T entity, bool save = true);
    
    Task<bool> RemoveByIdAsync(int id);
    
    Task UpdateAsync(T entity, bool save = true);
    
    Task<IEnumerable<T>> FindBySpecificationAsync(ISpecification<T>? specification = null);
    
}