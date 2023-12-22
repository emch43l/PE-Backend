﻿using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
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
            .HasForeignKey<Comment>("FileId")
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(comment => comment.Reactions)
            .WithOne(reaction => reaction.Comment)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(comment => comment.Previous)
            .WithOne()
            .HasForeignKey<Comment>("PreviousId");
        builder.ToTable("Comments");
    }
}