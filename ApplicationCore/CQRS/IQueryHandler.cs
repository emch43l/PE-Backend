using MediatR;

namespace ApplicationCore.CQRS;

public interface IQueryHandler<TQuery,TResult> : IRequestHandler<TQuery,TResult> where TResult: class where TQuery: IQuery<TResult>
{
    
}