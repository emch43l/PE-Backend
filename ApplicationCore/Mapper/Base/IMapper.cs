using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Common.Query;
using Domain.Model;

namespace ApplicationCore.Mapper;

public interface IMapper<TEntity,TResult> where TEntity: IEntity
{
    Task<List<TResult>> MapCollection(IQueryManager<TEntity> queryManager);

    Task<TResult?> MapSingle(IQueryManager<TEntity> queryManager);
    
    Func<TEntity, TResult> GetCompiledDelegate();
    
    TResult GetMappedResult(TEntity source);
    
    abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
    
}