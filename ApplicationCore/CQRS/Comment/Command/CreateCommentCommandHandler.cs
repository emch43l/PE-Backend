using ApplicationCore.Common.Implementation.Repository;
using ApplicationCore.CQRS.Base;

namespace ApplicationCore.CQRS.Comment.Command;

public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand,Guid>
{
    private readonly ICommentRepository _repository;

    public CreateCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}