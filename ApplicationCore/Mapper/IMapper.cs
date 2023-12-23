using System.Linq.Expressions;
using ApplicationCore.Dto;
using Domain.Common.Query;
using Domain.Model;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public interface IMapper<TEntity,TResult> where TEntity: IEntity
{
    Task<List<TResult>> MapCollection(ISelectableQuery<TEntity> query);

    Task<TResult?> MapSingle(ISelectableQuery<TEntity> query);
    
    Func<TEntity, TResult> GetCompiledDelegate();
    
    TResult GetMappedResult(TEntity source);
    
    abstract Expression<Func<TEntity, TResult>> GetMapperExpression();
    
}