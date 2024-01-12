using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Model;
using Infrastructure.Repository.Base;

namespace Infrastructure.Repository;

public class PostRepository : EntityRepositoryBase<Post>, IPostRepository
{
    public PostRepository(IApplicationDbContext context) : base(context)
    {
       
    }

    
}