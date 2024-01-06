using Domain.Model;
using Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class AlbumRatingEntityConfiguration : IEntityTypeConfiguration<AlbumRating>
{
    public void Configure(EntityTypeBuilder<AlbumRating> builder)
    {
        builder.HasKey(albumRating => albumRating.Id);
        builder
            .HasOne(albumRating => albumRating.Parent)
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