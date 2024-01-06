using System.Linq.Expressions;
using System.Linq;
using ApplicationCore.Dto;
using Domain.Model;

namespace ApplicationCore.Mapper;

public class PostWithUserAndSingleCommentMapper : AbstractMapper<Post,PostDto>
{
    
    //Trzeba zawsze zwracac lambde opakowana w Expression poniewaz w przeciwnym wypadku entity framework 
    //bedzie zmuszony do pobrania kazdego pola z tabeli bazy danych gdyz zapis Expression<...> jest dopierdo kompilowany
    //we wnetrzu entityframework i na podstawie parametrow zawartej w nim lambdy wybierane sa pola do zapytania
    // -- a przynajmniej tak sadze --
    public override Expression<Func<Post, PostDto>> GetMapperExpression()
    {
        return (Post entity) =>
            new PostDto
            {
                Id = entity.Guid,
                ReactionCount = entity!.ReactionCount,
                CommentCount = entity!.CommentCount,
                Title = entity.Title,
                User = new UserDto()
                {
                    Id = entity.User.Guid,
                    UserName = entity.User.UserName,
                },
                Comment = entity.Comments.AsQueryable()
                    .Select(new CommentWithUserMapper().GetMapperExpression())
                    .FirstOrDefault()
            };
    }
}