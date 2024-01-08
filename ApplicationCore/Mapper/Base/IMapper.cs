using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Model.Interface;

namespace ApplicationCore.Mapper.Base;

public interface IMapper<TEntity,TResult> where TEntity: IEntity
{
    Task<List<TResult>> MapCollection(IQueryManager<TEntity> queryManager, CancellationToken cancellationToken = default(CancellationToken));

    Task<TResult?> MapSingle(IQueryManager<TEntity> queryManager, CancellationToken cancellationToken = default(CancellationToken));
    
    Func<TEntity, TResult> GetCompiledDelegate();
    
    TResult GetMappedResult(TEntity source);
    
    abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
    
}