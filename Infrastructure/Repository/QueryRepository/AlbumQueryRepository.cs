using ApplicationCore.Common.Extension;
using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository.QueryRepository;

public class AlbumQueryRepository : AlbumRepository, IAlbumQueryRepository
{
    public AlbumQueryRepository(IApplicationDbContext context) : base(context)
    {
    }

    public IQueryManager<Album> GetQueryBySpecification(ISpecification<Album> specification)
    {
        return QueryManager<Album>.FromQuery(Context.Albums.ApplySpecification(specification));
    }
}