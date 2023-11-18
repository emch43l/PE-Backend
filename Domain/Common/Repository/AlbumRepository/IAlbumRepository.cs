using Domain.Model;

namespace Domain.Common.Repository.AlbumRepository;

public interface IAlbumRepository<TKey> : IGenericRepository<AlbumEntity<TKey>,TKey> where TKey : IEquatable<TKey>
{
    
}