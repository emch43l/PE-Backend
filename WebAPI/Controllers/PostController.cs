using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.CQRS.Post.Query;
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
    public async Task<IActionResult> GetPosts([FromQuery] int Page = 1, [FromQuery] int PageSize = 5)
    {
        GenericPaginatorResult<PostEntity> result = await _mediator.Send(new GetAllPostsPaginatedQuery(Page,PageSize));
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