namespace ApplicationCore.CQRS.Base;

public interface IQueryHandler<in TQ, TR>
{
    public Task<TR> Handle(TQ query, CancellationToken cancellationToken);
}