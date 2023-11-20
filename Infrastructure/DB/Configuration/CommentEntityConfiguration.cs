using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<GenericCommentEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericCommentEntity<int>> builder)
    {
        builder.HasKey(comment => comment.Id);
        builder
            .HasOne(comment => (UserEntity)comment.GenericUser)
            .WithMany(user => user.Comments)
            .HasForeignKey(comment => comment.UserId);
        builder
            .HasOne(comment => comment.GenericPost)
            .WithMany(post => post.Comments)
            .HasForeignKey("PostId")
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(comment => comment.GenericFile)
            .WithOne(file => file.Comment)
            .HasForeignKey<GenericCommentEntity<int>>("FileId")
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(comment => comment.Reactions)
            .WithOne(reaction => reaction.GenericComment)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(comment => comment.Previous)
            .WithOne()
            .HasForeignKey<GenericCommentEntity<int>>("PreviousId");
        builder.ToTable("Comments");
    }
}