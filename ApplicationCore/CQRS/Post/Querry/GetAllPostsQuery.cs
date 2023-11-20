using ApplicationCore.Common.Implementation.EntityImplementation;
using MediatR;

namespace ApplicationCore.CQRS.Post.Querry;

public class GetAllPostsQuery : IRequest<List<PostEntity>>
{
    
}