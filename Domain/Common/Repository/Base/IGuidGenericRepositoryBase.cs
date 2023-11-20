using Domain.Common.Identity;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TK') - covariance, contravariance
public interface IGuidGenericRepositoryBase<T, in TK> : IGenericRepositoryBase<T,TK> where T: IUidIdentity<TK> where TK: IEquatable<TK>
{
    Task<T?> FindByGuidAsync(Guid id);
    
    T? FindByGuid(Guid id);
    
    void RemoveByGuid(Guid id);
    
    void Update(Guid id, T o);
}