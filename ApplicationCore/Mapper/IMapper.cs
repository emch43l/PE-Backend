using System.Linq.Expressions;
using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Dto;
using Domain.Model;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public interface IMapper<IEntity,TResult> where TResult : class
{
    TResult GetMappedResult();
    Expression<Func<IEntity, CommentDto>> GetMapperExpression();
}