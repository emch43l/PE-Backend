using ApplicationCore.CQRS.PostOperations.Command;
using ApplicationCore.CQRS.PostOperations.Query;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;
using Domain.ValueObject;

namespace WebAPI.Controllers;

[ApiController]
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
        IGenericPaginatorResult<PostDto> result = 
            await _mediator.Send(new GetAllPostsPaginatedQuery(Page.FromValue(page),pageSize));
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route(":id")]
    public async Task<IActionResult> GetPostByGuid([FromQuery] Guid id)
    {
        PostWithCommentsDto post = await _mediator.Send(new GetPostWithCommentsQuery(id));
        return Ok(post);
    }

    [Authorize]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        Guid id = await _mediator.Send(
            new CreatePostCommand(request.Title, request.Description, HttpContext.User, request.Status)
            );

        return Ok(
            new { Id = id }
            );
    }

    [Authorize]
    [HttpPatch]
    [Route("update/:id")]
    public async Task<IActionResult> UpdatePost([FromQuery] Guid id, [FromBody] UpdatePostRequest request)
    {
        UpdatePostCommand command = new UpdatePostCommand(
            id,
            request.Title, 
            request.Description,
            request.Status, 
            HttpContext.User
            );
        await _mediator.Send(command);

        return NoContent();
    }

    [Authorize]
    [HttpDelete]
    [Route("delete/:id")]

    public async Task<IActionResult> DeletePost([FromQuery] Guid id)
    {
        await _mediator.Send(new DeletePostCommand(id, HttpContext.User));
        return NoContent();
    }

    [Authorize]
    [Route("all/my")]
    [HttpGet]
    public async Task<IActionResult> UserPosts([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        IGenericPaginatorResult<PostWithCommentsDto> result =
            await _mediator.Send(new GetCurrentUserPostsQuery(HttpContext.User,Page.FromValue(page),ItemNumber.FromValue(pageSize)));

        return Ok(result);
    }
    
}