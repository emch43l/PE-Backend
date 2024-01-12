using System.Linq.Expressions;
using Domain.Model.Interface;

namespace ApplicationCore.Mapper.Base;

public interface IMapper<TEntity,TResult> where TEntity: IEntity
{
    Func<TEntity, TResult> GetCompiledDelegate();
    
    TResult GetMappedResult(TEntity source);

    List<TResult> GetMappedResult(IEnumerable<TEntity> source);
    
    abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
    
}