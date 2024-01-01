using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository.QueryRepository;
using Domain.Common.Specification;
using Domain.Model.Generic;

namespace Infrastructure.Repository.QueryRepository;

public class AlbumQueryRepository : AlbumRepository, IAlbumQueryRepository
{
    public AlbumQueryRepository(IApplicationDbContext context, ISpecificationHandler<Album> specificationHandler) : base(context, specificationHandler)
    {
    }

    public IQueryManager<Album> GetQueryBySpecification(ISpecification<Album> specification)
    {
        return QueryManager<Album>.FromQuery(SpecificationHandler.Handle(Context.Albums, specification));
    }
}