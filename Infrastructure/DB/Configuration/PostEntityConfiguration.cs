using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class PostEntityConfiguration : IEntityTypeConfiguration<GenericPostEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericPostEntity<int>> builder)
    {
        builder.HasKey(post => post.Id);
        builder
            .HasMany(post => post.Files)
            .WithOne(file => file.Post)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(post => post.Reactions)
            .WithOne(reaction => reaction.GenericPost)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(post => post.Comments)
            .WithOne(comment => comment.GenericPost)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(post => (UserEntity)post.GenericUser)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.UserId);
        builder.ToTable("Posts");
    }
}