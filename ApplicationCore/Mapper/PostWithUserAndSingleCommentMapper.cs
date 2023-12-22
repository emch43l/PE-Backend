using System.Linq.Expressions;
using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Dto;
using Domain.Model.Generic;

namespace ApplicationCore.Mapper;

public class PostWithUserAndSingleCommentMapper : IMapper<PostEntity,PostDto>
{
    //Trzeba zawsze zwracac lambde opakowana w Expression poniewaz w przeciwnym wypadku entity framework 
    //bedzie zmuszony do pobrania kazdego pola z tabeli bazy danych gdyz zapis Expression<...> jest dopierdo kompilowany
    //we wnetrzu entityframework i na podstawie parametrow zawartej w nim lambdy wybierane sa pola do zapytania
    // -- a przynajmniej tak sadze --
    public PostDto GetMappedResult()
    {
        throw new NotImplementedException();
    }

    public Expression<Func<PostEntity, CommentDto>> GetMapperExpression()
    {
        return (PostEntity? entity) =>
            new PostDto
            {
                ReactionCount = entity!.ReactionCount,
                CommentCount = entity!.CommentCount,
                Title = entity.Title,
                User = new UserDto()
                {
                    Id = entity.User.Guid,
                    UserName = entity.User.UserName,
                },
                FirstComment = entity.Comments
                    .Select<CommentEntity,CommentDto>((new CommentWithUserMapper()).GetMapperExpression().Compile())
                    .FirstOrDefault()
            };
    }
}