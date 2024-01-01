﻿using System.Linq.Expressions;
using Domain.Common.Query;
using Domain.Model;

namespace ApplicationCore.Mapper;

public abstract class AbstractMapper<TEntity,TResult> : IMapper<TEntity,TResult> where TResult : class where TEntity: IEntity
{
    public async Task<List<TResult>> MapCollection(IQueryManager<TEntity> queryManager)
    {
        return await queryManager.MapList(GetMapperExpression());
    }

    public async Task<TResult?> MapSingle(IQueryManager<TEntity> queryManager)
    {
        return await queryManager.MapOne(GetMapperExpression());
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