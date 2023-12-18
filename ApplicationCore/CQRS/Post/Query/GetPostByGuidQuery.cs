using ApplicationCore.Common.Implementation.Entity;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetPostByGuidQuery : IRequest<PostEntity>
{
    public Guid Guid { get; set; }

    public GetPostByGuidQuery(Guid guid)
    {
        this.Guid = guid;
    }
}