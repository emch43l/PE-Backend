using Domain.Model;
using Infrastructure.Identity.Entity;
using Infrastructure.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class AlbumEntityConfiguration : IEntityTypeConfiguration<AlbumEntity<int>>
{
    public void Configure(EntityTypeBuilder<AlbumEntity<int>> builder)
    {
        builder.HasKey(album => album.Id);
        builder
            .HasMany(album => album.Files)
            .WithMany(file => file.Albums)
            .UsingEntity<AlbumFileJoin>(
                l => l.HasOne<FileEntity<int>>().WithMany().HasForeignKey("FileId").OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne<AlbumEntity<int>>().WithMany().HasForeignKey("AlbumId").OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey(entity => new { entity.AlbumId, entity.FileId });
                    j.ToTable("AlbumsFiles");
                });
        builder
             .HasMany(album => album.Rating)
             .WithOne(rating => rating.Album);
        builder
            .HasOne(album => (UserEntity)album.User)
            .WithMany(user => user.Albums)
            .HasForeignKey(post => post.UserId);
        builder.ToTable("Albums");
    }
}