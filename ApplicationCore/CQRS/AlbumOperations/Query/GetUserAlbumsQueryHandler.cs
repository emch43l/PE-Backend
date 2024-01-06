using ApplicationCore.Common.Implementation.Specification.AlbumSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Pagination;
using ApplicationCore.Service;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using Domain.Model;

namespace ApplicationCore.CQRS.AlbumOperations.Querry;

public class GetUserAlbumsQueryHandler : IQueryHandler<GetUserAlbumsQuery,IGenericPaginatorResult<AlbumDto>>
{
    private readonly IIdentityService _identityService;

    private readonly IAlbumQueryRepository _albumQueryRepository;

    private readonly IGenericPaginator _genericPaginator;

    public GetUserAlbumsQueryHandler(IIdentityService identityService, IAlbumQueryRepository albumQueryRepository, IGenericPaginator genericPaginator)
    {
        _identityService = identityService;
        _albumQueryRepository = albumQueryRepository;
        _genericPaginator = genericPaginator;
    }

    public async Task<IGenericPaginatorResult<AlbumDto>> Handle(GetUserAlbumsQuery request, CancellationToken cancellationToken)
    {
       IUser? user = await _identityService.GetUserByGuidAsync(request.UserId);
       if (user == null)
           throw new UserNotFoundException();

       IGenericPaginatorResult<AlbumDto> result =
           await _genericPaginator.Paginate(
               _albumQueryRepository.GetQueryBySpecification(
                   new GetUserAlbumsSpecification(user)).GetQuery(), new AlbumMapper(), request.Page.Value);

       return result;
    }
}