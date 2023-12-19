using System.Linq.Expressions;

namespace ApplicationCore.Mapper;

public interface IMapper<TEntity,TResult> where TEntity: class where TResult : class
{
    Expression<Func<TEntity, TResult>> GetMapperExpression();
}