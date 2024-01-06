using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CommentRepository : EntityRepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(IApplicationDbContext context) : base(context)
    {
        
    }

    
}