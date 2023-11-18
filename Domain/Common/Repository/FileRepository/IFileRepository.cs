using Domain.Model;

namespace Domain.Common.Repository.FileRepository;

public interface IFileRepository<TKey> : IGuidGenericRepository<FileEntity<TKey>, TKey> where TKey : IEquatable<TKey>
{
    
}