using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Model.Interface;

namespace ApplicationCore.Mapper.Base;

public abstract class AbstractMapper<TEntity,TResult> : IMapper<TEntity,TResult> where TResult : class where TEntity: IEntity
{
    public async Task<List<TResult>> MapCollection(IQueryManager<TEntity> queryManager, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await queryManager.GetList(GetMapperExpression());
    }

    public async Task<TResult?> MapSingle(IQueryManager<TEntity> queryManager, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await queryManager.GetOne(GetMapperExpression());
    }

    public Func<TEntity, TResult> GetCompiledDelegate()
    {
        return GetMapperExpression().Compile();
    }

    public TResult GetMappedResult(TEntity source)
    {
        return GetCompiledDelegate().Invoke(source);
    }

    public abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
}