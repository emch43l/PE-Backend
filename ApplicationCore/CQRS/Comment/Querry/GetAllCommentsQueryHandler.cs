using ApplicationCore.CQRS.Base;
using ApplicationCore.DTO;
using Domain.Common.Repository.CommentRepository;

namespace ApplicationCore.CQRS.Comment.Querry;

public class GetAllCommentsQueryHandler : IQueryHandler<GetAllCommentsQuery,List<CommentDTO>>
{
    private readonly ICommentRepository<int> _repository;

    public GetAllCommentsQueryHandler(ICommentRepository<int> repository)
    {
        _repository = repository;
    }

    public Task<List<CommentDTO>> Handle(GetAllCommentsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}