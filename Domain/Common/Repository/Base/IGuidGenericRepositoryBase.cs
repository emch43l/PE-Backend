﻿using Domain.Common.Identity;

namespace Domain.Common.Repository.Base;

// https://www.youtube.com/watch?v=Wp5iYQqHspg - ('in TK') - covariance, contravariance
public interface IGuidGenericRepositoryBase<T> : IGenericRepositoryBase<T> where T: IUidIdentity<int>
{
    Task<T?> FindByGuidAsync(Guid id, bool ignoreQueryFilters = false);
    
    T? FindByGuid(Guid id);
    
    Task<bool> RemoveByGuidAsync(Guid id);
    
    Task<bool> UpdateAsync(Guid id, T o);
}