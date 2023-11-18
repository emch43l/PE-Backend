using Domain.Model;

namespace Domain.Common.Repository.PostRepository;

public interface IPostRepository<TKey> : IGuidGenericRepository<PostEntity<TKey>,TKey> where TKey : IEquatable<TKey>
{
    
}