using Domain.Model;
using MediatR;

namespace ApplicationCore.CQRS.Post.Querry;

public class GetAllPostsQuery<TKey> : IRequest<List<PostEntity<TKey>>> where TKey: IEquatable<TKey>
{
    
}