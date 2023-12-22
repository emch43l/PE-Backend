using Domain.Common.Identity;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TKey') - covariance, contravariance
public interface IGenericRepositoryBase<T> where T: IUidIdentity<int>
{
    Task<T?> FindByIdAsync(int id);
    
    Task<List<T>> FindAllAsync();

    T? FindById(int id);
    
    List<T> FindAll();
    
    T Add(T o);
    
    void RemoveById(int id);
    
    void Update(int id, T o);
    
    IEnumerable<T> FindBySpecification(ISpecification<T>? specification = null);

    IQueryable<T> GetQueryBySpecification(ISpecification<T>? specification = null);
}