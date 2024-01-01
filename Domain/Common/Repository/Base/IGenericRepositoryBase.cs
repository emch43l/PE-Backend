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

    T? FindById(int id);
    
    List<T> FindAll();
    
    void Add(T o);
    
    bool RemoveById(int id);
    
    bool Update(int id, T o);
    
    IEnumerable<T> FindBySpecification(ISpecification<T>? specification = null);

    IQueryable<T> GetQueryBySpecification(ISpecification<T>? specification = null);
}