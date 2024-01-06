using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors;

public class CommentReactionInterceptor : AbstractReactionInterceptor<Comment,CommentReaction>
{
    
}