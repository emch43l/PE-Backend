using ApplicationCore.Common.Interface;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = Domain.Model.Generic.File;
using UserEntity = Infrastructure.Identity.Entity.UserEntity;

namespace Infrastructure.DB;

public class ApplicationDbContext : IdentityDbContext<UserEntity,UserRoleEntity,int>, IApplicationDbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumRating> AlbumRatings { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentReaction> CommentReactions { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public ApplicationDbContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-7J9U791;Database=PE;TrustServerCertificate=true;Integrated Security=true"); 
        }
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
        
        // builder.ApplyConfiguration(new AlbumEntityConfiguration());
        // builder.ApplyConfiguration(new AlbumRatingEntityConfiguration());
        // builder.ApplyConfiguration(new CommentEntityConfiguration());
        // builder.ApplyConfiguration(new CommentReactionEntityConfiguration());
        // builder.ApplyConfiguration(new FileEntityConfiguration());
        // builder.ApplyConfiguration(new PostReactionEntityConfiguration());
        // builder.ApplyConfiguration(new PostEntityConfiguration());
    }
}