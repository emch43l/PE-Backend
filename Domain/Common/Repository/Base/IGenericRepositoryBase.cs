using Domain.Common.Identity;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TKey') - covariance, contravariance
public interface IGenericRepositoryBase<T, in TKey> where T: IUidIdentity<TKey> where TKey: IEquatable<TKey>
{
    Task<T?> FindByIdAsync(TKey id);
    
    Task<List<T>> FindAllAsync();

    T? FindById(TKey id);
    
    List<T> FindAll();
    
    T Add(T o);
    
    void RemoveById(TKey id);
    
    void Update(TKey id, T o);
    
    IEnumerable<T> FindBySpecification(ISpecification<T>? specification = null);

    IQueryable<T> GetQuery();

    IQueryable<T> GetQueryBySpecification(ISpecification<T>? specification = null);
}