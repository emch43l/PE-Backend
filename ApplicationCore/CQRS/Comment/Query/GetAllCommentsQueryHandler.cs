using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.CQRS.Base;
using ApplicationCore.Dto;

namespace ApplicationCore.CQRS.Comment.Query;

public class GetAllCommentsQueryHandler : IQueryHandler<GetAllCommentsQuery,List<CommentDto>>
{
    private readonly ICommentRepository _repository;

    public GetAllCommentsQueryHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public Task<List<CommentDto>> Handle(GetAllCommentsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}