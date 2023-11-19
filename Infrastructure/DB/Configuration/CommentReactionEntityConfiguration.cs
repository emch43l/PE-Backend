using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class CommentReactionEntityConfiguration : IEntityTypeConfiguration<CommentReactionEntity<int>>
{
    public void Configure(EntityTypeBuilder<CommentReactionEntity<int>> builder)
    {
        builder.HasKey(commentReaction => commentReaction.Id);
        builder
            .HasOne(commentReaction => commentReaction.Comment)
            .WithMany(comment => comment.Reactions)
            .HasForeignKey("CommentId");
        builder
            .HasOne(commentReaction => (UserEntity)commentReaction.User)
            .WithMany(user => user.CommentReactions)
            .HasForeignKey(postReaction => postReaction.UserId);
        builder.ToTable("CommentReactions");
    }
}