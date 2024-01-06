using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class PostReactionEntityConfiguration : IEntityTypeConfiguration<PostReaction>
{
    public void Configure(EntityTypeBuilder<PostReaction> builder)
    {
        builder.HasKey(postReaction => postReaction.Id);
        builder
            .HasOne(postReaction => postReaction.Parent)
            .WithMany(post => post.Reactions)
            .HasForeignKey("PostId");
        builder
            .HasOne(postReaction => (UserEntity)postReaction.User)
            .WithMany(user => user.PostReactions)
            .HasForeignKey(postReaction => postReaction.UserId);
        builder.ToTable("PostReactions");
    }
}