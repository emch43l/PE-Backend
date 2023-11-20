using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Infrastructure.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class AlbumEntityConfiguration : IEntityTypeConfiguration<GenericAlbumEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericAlbumEntity<int>> builder)
    {
        builder.HasKey(album => album.Id);
        builder
            .HasMany(album => album.Files)
            .WithMany(file => file.Albums)
            .UsingEntity<AlbumFileJoin>(
                l => l.HasOne<GenericFileEntity<int>>().WithMany().HasForeignKey("FileId").OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne<GenericAlbumEntity<int>>().WithMany().HasForeignKey("AlbumId").OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey(entity => new { entity.AlbumId, entity.FileId });
                    j.ToTable("AlbumsFiles");
                });
        builder
             .HasMany(album => album.Rating)
             .WithOne(rating => rating.GenericAlbum);
        builder
            .HasOne(album => (UserEntity)album.GenericUser)
            .WithMany(user => user.Albums)
            .HasForeignKey(post => post.UserId);
        builder.ToTable("Albums");
    }
}