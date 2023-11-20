using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface ICommentRepository<in TKey,TEntity> : IGuidGenericRepositoryBase<TEntity,TKey> where TKey : IEquatable<TKey> where TEntity: GenericCommentEntity<TKey>
{
    
}