using ApplicationCore.CQRS.CommentOperations.Command;
using ApplicationCore.CQRS.PostOperations.Command;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize]
[ApiController]
[Route("reaction")]
public class ReactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("post")]
    [HttpPost]
    public async Task<IActionResult> AddReactionToPost([FromQuery] Guid postId, [FromBody] ReactionTypeEnum reaction)
    {
        await _mediator.Send(new AddReactionToPostCommand(postId,reaction,HttpContext.User));

        return Ok();
    }

    [Route("comment")]
    [HttpPost]
    public async Task<IActionResult> AddReactionToComment([FromQuery] Guid commentId, [FromBody] ReactionTypeEnum reaction)
    {
        await _mediator.Send(new AddReactionToCommentCommand(commentId, reaction, HttpContext.User));

        return Ok();
    }

    /*
    [Route("album")]
    public async Task<IActionResult> AddRatingToAlbum([FromQuery] Guid albumId)
    {
        
    }*/
}