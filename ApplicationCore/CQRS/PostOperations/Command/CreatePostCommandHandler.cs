using ApplicationCore.Service;
using Domain.Common.Repository;
using Domain.Model.Generic;
using FluentValidation;
using FluentValidation.Results;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace ApplicationCore.CQRS.PostOperations.Command;

public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
{
    private readonly IValidator<CreatePostCommand> _validator;
    private readonly IPostRepository _postRepository;
    private readonly IIdentityService _identityService;

    public CreatePostCommandHandler(IValidator<CreatePostCommand> validator, IPostRepository postRepository, IIdentityService identityService)
    {
        _validator = validator;
        _postRepository = postRepository;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request,cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(
                String.Join(',', validationResult.Errors.Select(vr => vr.ErrorMessage))
                );
        }

        IUser user = await _identityService.GetUserByClaim(request.User);
        
        Post post = new Post()
        {
            Guid = Guid.NewGuid(),
            Description = request.Description,
            Title = request.Title,
            Date = DateTime.Now,
            Status = request.Status,
            UserId = user.Id
        };

        await _postRepository.AddAsync(post);
        await _postRepository.SaveChangesAsync(cancellationToken);

        return post.Guid;
    }
}