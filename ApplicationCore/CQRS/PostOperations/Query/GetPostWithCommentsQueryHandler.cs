using ApplicationCore.Common.Implementation.Specification.CommentSpecification;
using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using Domain.Common.Repository.QueryRepository;
using Domain.Exception;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostWithCommentsQueryHandler : IQueryHandler<GetPostWithCommentsQuery,PostWithCommentsDto>
{
    private readonly IPostQueryRepository _postRepository;

    private readonly ICommentQueryRepository _commentQueryRepository;

    public GetPostWithCommentsQueryHandler(IPostQueryRepository postRepository, ICommentQueryRepository commentQueryRepository)
    {
        _postRepository = postRepository;
        _commentQueryRepository = commentQueryRepository;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        IMapper<Post, PostWithCommentsDto> postMapper = new PostWithCommentsMapper();
        IMapper<Comment, CommentDto> commentMapper = new CommentWithUserMapper();

        Post? post = await _postRepository
            .GetPostWithUserQuery(request.PostId)
            .ApplySpecification(new PublicPostSpecification()).GetQuery().FirstOrDefaultAsync();
        
        if (post == null)
            throw new PostNotFoundException();

        List<CommentDto> commentDtos = await commentMapper.MapCollection(
            _commentQueryRepository
                .GetPostCommentsQuery(post)
                .ApplySpecification(new GetFewCommentsWithUserSpecification())
        );

        PostWithCommentsDto postWithCommentsDto = postMapper.GetMappedResult(post);
        postWithCommentsDto.Comments = commentDtos;
        
        
        return postWithCommentsDto;
    }
}