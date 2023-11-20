using ApplicationCore.Common.Implementation.EntityImplementation;
using MediatR;

namespace ApplicationCore.CQRS.Post.Querry;

public class GetPostByGuidQuery : IRequest<PostEntity>
{
    public Guid Guid { get; set; }

    public GetPostByGuidQuery(Guid guid)
    {
        this.Guid = guid;
    }
}