using System.Reflection;
using ApplicationCore.Common.Interface;
using Domain.Model;
using Domain.Model.Interface;
using Infrastructure.DB.Configuration;
using Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB;

public class ApplicationDbContext : IdentityDbContext<UserEntity,UserRoleEntity,int>, IApplicationDbContext<int>
{
    public DbSet<AlbumEntity<int>> Albums { get; set; }
    public DbSet<AlbumRatingEntity<int>> AlbumRatings { get; set; }
    public DbSet<CommentEntity<int>> Comments { get; set; }
    public DbSet<CommentReactionEntity<int>> CommentReactions { get; set; }
    public DbSet<FileEntity<int>> Files { get; set; }
    public DbSet<PostEntity<int>> Posts { get; set; }
    public DbSet<PostReactionEntity<int>> PostReactions { get; set; }

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
        
        builder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Configuration).Assembly);
        
        // builder.ApplyConfiguration(new AlbumEntityConfiguration());
        // builder.ApplyConfiguration(new AlbumRatingEntityConfiguration());
        // builder.ApplyConfiguration(new CommentEntityConfiguration());
        // builder.ApplyConfiguration(new CommentReactionEntityConfiguration());
        // builder.ApplyConfiguration(new FileEntityConfiguration());
        // builder.ApplyConfiguration(new PostReactionEntityConfiguration());
        // builder.ApplyConfiguration(new PostEntityConfiguration());
    }
}