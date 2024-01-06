using System.Data.Common;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.DB.Interceptors;

public class PostReactionInterceptor : AbstractReactionInterceptor<Post,PostReaction>
{
    
}