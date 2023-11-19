﻿using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class AlbumRatingEntityConfiguration : IEntityTypeConfiguration<AlbumRatingEntity<int>>
{
    public void Configure(EntityTypeBuilder<AlbumRatingEntity<int>> builder)
    {
        builder.HasKey(albumRating => albumRating.Id);
        builder
            .HasOne(albumRating => albumRating.Album)
            .WithMany(album => album.Rating)
            .HasForeignKey("AlbumId");
        builder
            .HasOne(albumRating => (UserEntity)albumRating.User)
            .WithMany(user => user.AlbumRatings)
            .HasForeignKey(albumRating => albumRating.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.ToTable("AlbumRatings");
    }
}