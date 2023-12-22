using Domain.Common.Identity;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TK') - covariance, contravariance
public interface IGuidGenericRepositoryBase<T> : IGenericRepositoryBase<T> where T: IUidIdentity<int>
{
    Task<T?> FindByGuidAsync(Guid id);
    
    T? FindByGuid(Guid id);
    
    void RemoveByGuid(Guid id);
    
    void Update(Guid id, T o);
}