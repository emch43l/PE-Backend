using Domain.Common.Query;
using Domain.Model.Generic;

namespace Domain.Common.Repository.QueryRepository;

public interface IPostQueryRepository : IQueryRepositoryBase<Post>, IPostRepository
{
    IQueryManager<Post> GetUserPostsWithCommentsQuery(IUser user, int commentCount);
    
    IQueryManager<Post> GetPostWithCommentsQuery(Guid guid, int commentCount);
    
    IQueryManager<Post> GetPostsWithUserAndFirstCommentQuery();
}