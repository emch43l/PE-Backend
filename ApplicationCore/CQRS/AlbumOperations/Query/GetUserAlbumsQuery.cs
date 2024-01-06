using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;

namespace ApplicationCore.CQRS.AlbumOperations.Query;

public class GetUserAlbumsQuery : IQuery<IGenericPaginatorResult<AlbumDto>>
{
    public Guid UserId { get; set; }
    
    public Page Page { get; set; }

    public GetUserAlbumsQuery(Guid id, Page page)
    {
        Page = page;
        UserId = id;
    }
}