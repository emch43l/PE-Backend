using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity<int>>
{
    public void Configure(EntityTypeBuilder<CommentEntity<int>> builder)
    {
        builder.HasKey(comment => comment.Id);
        builder
            .HasOne(comment => (UserEntity)comment.User)
            .WithMany(user => user.Comments)
            .HasForeignKey(comment => comment.UserId);
        builder
            .HasOne(comment => comment.Post)
            .WithMany(post => post.Comments)
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(comment => comment.File)
            .WithOne(file => file.Comment)
            .HasForeignKey<CommentEntity<int>>("FileId")
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(comment => comment.Reactions)
            .WithOne(reaction => reaction.Comment)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(comment => comment.Previous)
            .WithOne()
            .HasForeignKey<CommentEntity<int>>("PreviousId");
        builder.ToTable("Comments");
    }
}