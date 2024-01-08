using ApplicationCore.Common.Implementation.Specification.CommentSpecification;
using ApplicationCore.Common.Implementation.Specification.PostSpecification;
using ApplicationCore.Dto;
using ApplicationCore.Mapper;
using ApplicationCore.Mapper.Base;
using Domain.Common.Repository;
using Domain.Exception;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.CQRS.PostOperations.Query;

public class GetPostWithCommentsQueryHandler : IQueryHandler<GetPostWithCommentsQuery,PostWithCommentsDto>
{
    private readonly IPostRepository _postRepository;

    private readonly ICommentRepository _commentRepository;

    public GetPostWithCommentsQueryHandler(IPostRepository postRepository, ICommentRepository commentQueryRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentQueryRepository;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        IMapper<Post, PostWithCommentsDto> postMapper = new PostWithCommentsMapper();
        IMapper<Comment, CommentDto> commentMapper = new CommentWithUserMapper();

        Post? post = await _postRepository
            .GetQueryManager()
            .ApplySpecification(new GetPublicPostWithUserSpecification(request.PostId))
            .GetQuery().FirstOrDefaultAsync(cancellationToken);
        
        if (post == null)
            throw new PostNotFoundException();

        List<CommentDto> commentDtos = await commentMapper.MapCollection(
            _commentRepository
                .GetQueryManager()
                .ApplySpecification(new GetFewCommentsWithUserSpecification(post.Id))
        );

        PostWithCommentsDto postWithCommentsDto = postMapper.GetMappedResult(post);
        postWithCommentsDto.Comments = commentDtos;
        
        
        return postWithCommentsDto;
    }
}