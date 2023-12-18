using ApplicationCore.Common.Implementation.Entity;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsQuery : IRequest<List<PostEntity>>
{
    
}