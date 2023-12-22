using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface IPostRepository : IGuidGenericRepositoryBase<Post> 
{
    IQueryable<Post> GetPostWithCommentsQuery(Guid guid, int commentCount);
    IQueryable<Post> GetPostsWithUserAndFirstCommentQuery();
}