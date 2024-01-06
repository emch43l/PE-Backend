using Domain.Common.Query;
using Domain.Model;

namespace Domain.Common.Repository.QueryRepository;

public interface ICommentQueryRepository : IQueryRepositoryBase<Comment>, ICommentRepository
{
    IQueryManager<Comment> GetPostCommentsQuery(Post post);

    IQueryManager<Comment> GetCommentCommentsQuery(Comment comment);
}