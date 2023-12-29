using Domain.Enum;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(post => post.Id);
        builder
            .HasMany(post => post.Files)
            .WithOne(file => file.Post)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(post => post.Reactions)
            .WithOne(reaction => reaction.Post)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(post => post.Comments)
            .WithOne(comment => comment.Post)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(post => (UserEntity)post.User)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.UserId);

        builder.HasQueryFilter(p => p.Status == StatusEnum.Visible);
        
        builder.ToTable("Posts");
    }
}