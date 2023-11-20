using ApplicationCore.Common.Implementation.RepositoryImplementation;
using ApplicationCore.CQRS.Base;
using ApplicationCore.DTO;

namespace ApplicationCore.CQRS.Comment.Query;

public class GetAllCommentsQueryHandler : IQueryHandler<GetAllCommentsQuery,List<CommentDTO>>
{
    private readonly ICommentRepository _repository;

    public GetAllCommentsQueryHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public Task<List<CommentDTO>> Handle(GetAllCommentsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}