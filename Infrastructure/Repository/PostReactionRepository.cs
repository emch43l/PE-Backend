using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Model.Generic;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public class PostReactionRepository : EntityRepositoryBase<PostReaction>, IPostReactionRepository
{
    public PostReactionRepository(IApplicationDbContext context) : base(context)
    {
        
    }
}