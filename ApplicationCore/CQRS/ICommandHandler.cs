using MediatR;

namespace ApplicationCore.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Guid> where TCommand: ICommand
{

}