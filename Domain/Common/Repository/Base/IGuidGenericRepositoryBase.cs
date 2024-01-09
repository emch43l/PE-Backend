using Domain.Model.Interface;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TK') - covariance, contravariance
public interface IGuidGenericRepositoryBase<T> : IGenericRepositoryBase<T> where T: IEntity
{
    Task<T?> FindByGuidAsync(Guid id);
    
}