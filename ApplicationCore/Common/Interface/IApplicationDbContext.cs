using ApplicationCore.Common.Implementation.EntityImplementation;
using Domain.Model.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Interface;

public interface IApplicationDbContext
{
    public DbSet<AlbumEntity> Albums { get; set; }
    
    public DbSet<AlbumRatingEntity> AlbumRatings { get; set; }
    
    public DbSet<CommentEntity> Comments { get; set; }
    
    public DbSet<CommentReactionEntity> CommentReactions { get; set; }
    
    public DbSet<FileEntity> Files { get; set; }
    
    public DbSet<PostEntity> Posts { get; set; }
    
    public DbSet<PostReactionEntity> PostReactions { get; set; }
}