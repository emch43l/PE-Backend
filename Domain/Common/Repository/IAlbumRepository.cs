using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface IAlbumRepository<in TKey,TEntity> : IGenericRepositoryBase<TEntity,TKey> where TKey : IEquatable<TKey> where TEntity: GenericAlbumEntity<TKey>
{
    
}