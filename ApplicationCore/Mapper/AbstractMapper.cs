using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Mapper;

public abstract class AbstractMapper<TEntity,TResult> : IMapper<TEntity,TResult> where TResult : class where TEntity: IEntity
{
    public async Task<List<TResult>> MapCollection(ISelectableQuery<TEntity> query)
    {
        return await query.SelectList(GetMapperExpression());
    }

    public async Task<TResult?> MapSingle(ISelectableQuery<TEntity> query)
    {
        return await query.SelectOne(GetMapperExpression());
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