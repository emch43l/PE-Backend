using ApplicationCore.Dto;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostWithCommentsQuery : IRequest<PostWithCommentsDto>
{
    public Guid PostId { get; set; }
    public int CommentCount { get; set; }
    
    public GetPostWithCommentsQuery(Guid postId,int commentCount = 10)
    {
        PostId = postId;
        CommentCount = commentCount;
    }
}