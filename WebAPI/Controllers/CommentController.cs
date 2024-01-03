using ApplicationCore.CQRS.CommentOperations.Query;
using ApplicationCore.Dto;
using ApplicationCore.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("comments")]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("post/:id/:page")]
    public async Task<IActionResult> GetPostComments(Guid id, int page)
    {
        IGenericPaginatorResult<CommentDto> result = await _mediator.Send(new GetPostCommentsQuery(id, page));

        return Ok(result);
    }

    [HttpGet]
    [Route("replies/:id/:page")]
    public async Task<IActionResult> GetCommentReplies(Guid id, int page)
    {
        IGenericPaginatorResult<CommentDto> result = await _mediator.Send(new GetCommentRepliesQuery(id, page));

        return Ok(result);
    }

    //[Route(":id")]
    //public IActionResult GetComment(Guid id)
    //{
    //    throw new NotImplementedException();
    //}
}