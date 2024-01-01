using MediatR;

namespace ApplicationCore.CQRS;

public interface IQuery<TResult> : IRequest<TResult> where TResult: class
{
    
}