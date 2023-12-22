using System.Linq.Expressions;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Mapper;

public abstract class AbstractMapper<TEntity,TResult> : IMapper<TEntity,TResult> where TResult : class where TEntity: IEntity
{
    public async Task<List<TResult>> MapCollection(IQueryable<TEntity> query)
    {
        return await query.Select(GetMapperExpression()).ToListAsync();
    }

    public async Task<TResult?> MapSingle(IQueryable<TEntity> query)
    {
        return await query.Select(GetMapperExpression()).FirstOrDefaultAsync();
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