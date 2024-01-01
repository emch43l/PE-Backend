using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostByGuidQuery : IQuery<Post>
{
    public Guid Guid { get; set; }

    public GetPostByGuidQuery(Guid guid)
    {
        this.Guid = guid;
    }
}