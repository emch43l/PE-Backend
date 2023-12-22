using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface IPostRepository<in TKey,TEntity> : IGuidGenericRepositoryBase<TEntity,TKey> where TKey : IEquatable<TKey> where TEntity: GenericPostEntity<TKey>
{
    Task<TEntity?> GetPostWithComments(Guid guid, int commentCount);
    IQueryable<TEntity> GetPostsWithUserAndFirstCommentQuery();
}