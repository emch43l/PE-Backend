using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Model;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public interface IMapper<TEntity,TResult>
{
    Task<List<TResult>> MapCollection(IQueryable<TEntity> query);

    Task<TResult?> MapSingle(IQueryable<TEntity> query);
    
    Func<TEntity, TResult> GetCompiledDelegate();
    
    TResult GetMappedResult(TEntity source);
    
    abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
    
}