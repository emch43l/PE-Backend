using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity<int>>
{
    public void Configure(EntityTypeBuilder<PostEntity<int>> builder)
    {
        builder.HasKey(post => post.Id);
        builder
            .HasMany(post => post.Files)
            .WithOne(file => file.Post);
        builder
            .HasMany(post => post.Reactions)
            .WithOne(reaction => reaction.Post);
        builder
            .HasMany(post => post.Comments)
            .WithOne(comment => comment.Post);
        builder
            .HasOne(post => (UserEntity)post.User)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.UserId);
    }
}