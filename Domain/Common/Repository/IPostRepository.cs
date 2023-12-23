using Domain.Common.Query;
using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface IPostRepository : IGuidGenericRepositoryBase<Post> 
{
    ISelectableQuery<Post> GetPostWithCommentsQuery(Guid guid, int commentCount);
    ISelectableQuery<Post> GetPostsWithUserAndFirstCommentQuery();
}