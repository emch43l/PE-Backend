using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class CommentReactionEntityConfiguration : IEntityTypeConfiguration<GenericCommentReactionEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericCommentReactionEntity<int>> builder)
    {
        builder.HasKey(commentReaction => commentReaction.Id);
        builder
            .HasOne(commentReaction => commentReaction.GenericComment)
            .WithMany(comment => comment.Reactions)
            .HasForeignKey("CommentId");
        builder
            .HasOne(commentReaction => (UserEntity)commentReaction.GenericUser)
            .WithMany(user => user.CommentReactions)
            .HasForeignKey(postReaction => postReaction.UserId);
        builder.ToTable("CommentReactions");
    }
}