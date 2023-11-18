using ApplicationCore.CQRS.Base;
using Domain.Common.Repository.CommentRepository;

namespace ApplicationCore.CQRS.Comment.Command.CreateComment;

public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand,Guid>
{
    private readonly ICommentRepository<int> _repository;

    public CreateCommentCommandHandler(ICommentRepository<int> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}