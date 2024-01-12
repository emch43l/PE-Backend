using System.Linq.Expressions;
using Domain.Model.Interface;

namespace ApplicationCore.Mapper.Base;

public abstract class AbstractMapper<TEntity,TResult> : IMapper<TEntity,TResult> where TResult : class where TEntity: IEntity
{
    public Func<TEntity, TResult> GetCompiledDelegate()
    {
        return GetMapperExpression().Compile();
    }

    public TResult GetMappedResult(TEntity source)
    {
        return GetCompiledDelegate().Invoke(source);
    }

    public List<TResult> GetMappedResult(IEnumerable<TEntity> source)
    {
        return source.Select(GetMappedResult).ToList();
    }

    public abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
}