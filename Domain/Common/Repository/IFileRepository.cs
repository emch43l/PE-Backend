using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface IFileRepository<TKey> : IGuidGenericRepositoryBase<GenericFileEntity<TKey>, TKey> where TKey : IEquatable<TKey>
{
    
}