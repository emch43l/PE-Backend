using Domain.Common.Query;
using Domain.Model;

namespace Domain.Common.Repository.QueryRepository;

public interface IPostQueryRepository : IQueryRepositoryBase<Post>, IPostRepository
{
    IQueryManager<Post> GetUserPostsWithCommentsQuery(IUser user, int commentCount);
    
    IQueryManager<Post> GetPostWithUserQuery(Guid guid);
    
    IQueryManager<Post> GetPublicPostsWithUserAndFirstCommentQuery();
}