using Domain.Common.Query;
using Domain.Common.Repository.Base;
using Domain.Model.Generic;

namespace Domain.Common.Repository;

public interface ICommentRepository : IGuidGenericRepositoryBase<Comment>
{
    ISelectableQuery<Comment> GetPostCommentsQuery(Post post);
}