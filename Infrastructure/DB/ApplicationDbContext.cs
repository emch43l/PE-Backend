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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostEntityConfiguration());
        base.OnModelCreating(builder);
    }
}