using System.Linq.Expressions;
using ApplicationCore.Common.Implementation.Entity;
using ApplicationCore.Dto;

namespace ApplicationCore.Mapper;

public class PostWithUserAndSingleCommentMapper : IMapper<PostEntity,PostDto>
{
    //Trzeba zawsze zwracac lambde opakowana w Expression poniewaz w przeciwnym wypadku entity framework 
    //bedzie zmuszony do pobrania kazdego pola z tabeli bazy danych gdyz zapis Expression<...> jest dopierdo kompilowany
    //we wnetrzu entityframework i na podstawie parametrow zawartej w nim lambdy wybierane sa pola do zapytania
    // -- a przynajmniej tak sadze --
    public Expression<Func<PostEntity, PostDto>> GetMapperExpression()
    {
        return (PostEntity entity) =>
            new PostDto
            {
                ReactionCount = entity.ReactionCount,
                CommentCount = entity.CommentCount,
                Title = entity.Title,
                User = new UserDto()
                {
                    Id = entity.User.Guid,
                    UserName = entity.User.UserName,
                },
                FirstComment = entity.Comments.Select(comment => new CommentDto()
                {
                    ReactionCount = comment.ReactionCount,
                    Content = comment.Content,
                    DateCreated = comment.DateCreated,
                    UserName = comment.User.UserName
                }).FirstOrDefault()
            };
    }
}