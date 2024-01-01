using MediatR;

namespace ApplicationCore.CQRS;

public interface ICommand : IRequest<Guid>
{
    
}