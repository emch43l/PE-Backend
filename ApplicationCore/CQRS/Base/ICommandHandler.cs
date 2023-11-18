namespace ApplicationCore.CQRS.Base;

public interface ICommandHandler<TC,TR> 
{
    public Task<TR> Handle(TC command, CancellationToken cancellationToken);
}