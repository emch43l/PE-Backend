using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.CQRS.Post.Query;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("post")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetPosts([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        IGenericPaginatorResult<PostDto> result = await _mediator.Send(new GetAllPostsPaginatedQuery(page,pageSize));
        return Ok(result);
    }

    [HttpGet]
    [Route(":guid")]
    public async Task<IActionResult> GetPostByGuid([FromQuery] Guid id)
    {
        PostEntity post = await _mediator.Send(new GetPostByGuidQuery(id));
        return Ok(post);
    }
    
}