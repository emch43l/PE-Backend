using ApplicationCore.Common.Implementation.EntityImplementation;
using ApplicationCore.CQRS.Post.Querry;
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
    public async Task<IActionResult> GetPosts()
    {
        List<PostEntity> posts = await _mediator.Send(new GetAllPostsQuery());
        return Ok(posts);
    }

    [HttpGet]
    [Route(":guid")]
    public async Task<IActionResult> GetPostByGuid([FromQuery] Guid id)
    {
        PostEntity post = await _mediator.Send(new GetPostByGuidQuery(id));
        return Ok(post);
    }
    
}