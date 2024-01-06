using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Model;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public class AlbumRepository : EntityRepositoryBase<Album>, IAlbumRepository
{
    public AlbumRepository(IApplicationDbContext context) : base(context)
    {
        
    }

    
}