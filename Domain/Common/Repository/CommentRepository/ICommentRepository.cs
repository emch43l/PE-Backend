using Domain.Model;

namespace Domain.Common.Repository.CommentRepository;

public interface ICommentRepository<TKey> : IGuidGenericRepository<CommentEntity<TKey>,TKey> where TKey : IEquatable<TKey>
{
    
}