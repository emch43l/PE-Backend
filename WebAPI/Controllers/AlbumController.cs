using ApplicationCore.CQRS.AlbumOperations.Querry;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using Domain.ValueObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("albums")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlbumController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("user")]
    public async Task<IActionResult> GetUserAlbums([FromQuery] Guid userId, [FromQuery] int page)
    {
        IGenericPaginatorResult<AlbumDto> result = await _mediator.Send(new GetUserAlbumsQuery(userId, Page.FromValue(page)));

        return Ok(result);
    }
}