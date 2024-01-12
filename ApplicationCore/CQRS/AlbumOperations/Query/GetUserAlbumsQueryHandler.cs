using ApplicationCore.Common.Implementation.Specification.AlbumSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model.Interface;

namespace ApplicationCore.CQRS.AlbumOperations.Query;

public class GetUserAlbumsQueryHandler : IQueryHandler<GetUserAlbumsQuery,IGenericPaginatorResult<AlbumDto>>
{
    private readonly IIdentityService _identityService;

    private readonly IAlbumRepository _albumQueryRepository;

    private readonly IPaginator _paginator;

    public GetUserAlbumsQueryHandler(IIdentityService identityService, IAlbumRepository albumQueryRepository, IPaginator paginator)
    {
        _identityService = identityService;
        _albumQueryRepository = albumQueryRepository;
        _paginator = paginator;
    }

    public async Task<IGenericPaginatorResult<AlbumDto>> Handle(GetUserAlbumsQuery request, CancellationToken cancellationToken)
    {
       IUser? user = await _identityService.GetUserByGuidAsync(request.UserId);
       if (user == null)
           throw new UserNotFoundException();

       IGenericPaginatorResult<AlbumDto> result =
           await _paginator.Paginate(
               _albumQueryRepository
                   .GetQuery(new GetUserAlbumsSpecification(user)), new AlbumMapper(), request.Page.Value);

       return result;
    }
}