using ApplicationCore.CQRS.Post.Querry;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> GetPosts()
    {
        List<PostEntity<int>> posts = await _mediator.Send(new GetAllPostsQuery<int>());
        return Ok(posts);
    }
    
}