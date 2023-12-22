using Domain.Model.Generic;
using MediatR;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetAllPostsQuery : IRequest<List<Post>>
{
    
}