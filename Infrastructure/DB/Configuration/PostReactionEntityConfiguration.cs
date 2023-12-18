using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class PostReactionEntityConfiguration : IEntityTypeConfiguration<GenericPostReactionEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericPostReactionEntity<int>> builder)
    {
        builder.HasKey(postReaction => postReaction.Id);
        builder
            .HasOne(postReaction => postReaction.GenericPost)
            .WithMany(post => post.Reactions)
            .HasForeignKey("PostId");
        builder
            .HasOne(postReaction => (UserEntity)postReaction.User)
            .WithMany(user => user.PostReactions)
            .HasForeignKey(postReaction => postReaction.UserId);
        builder.ToTable("PostReactions");
    }
}