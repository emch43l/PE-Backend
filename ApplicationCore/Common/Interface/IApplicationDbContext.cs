using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Common.Interface;

public interface IApplicationDbContext<TKey> where TKey: IEquatable<TKey>
{
    public DbSet<AlbumEntity<TKey>> Albums { get; set; }
    
    public DbSet<AlbumRatingEntity<TKey>> AlbumRatings { get; set; }
    
    public DbSet<CommentEntity<TKey>> Comments { get; set; }
    
    public DbSet<CommentReactionEntity<TKey>> CommentReactions { get; set; }
    
    public DbSet<FileEntity<TKey>> Files { get; set; }
    
    public DbSet<PostEntity<TKey>> Posts { get; set; }
    
    public DbSet<PostReactionEntity<TKey>> PostReactions { get; set; }
}