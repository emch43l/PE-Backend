using Domain.Model.Generic;

namespace Domain.Common.Repository.QueryRepository;

public interface IAlbumQueryRepository : IQueryRepositoryBase<Album>, IAlbumRepository
{
    
}