using Domain.Model;
using Infrastructure.Identity.Entity;
using Infrastructure.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Domain.Model.File;

namespace Infrastructure.DB.Configuration;

public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(album => album.Id);
        builder
            .HasMany(album => album.Files)
            .WithMany(file => file.Albums)
            .UsingEntity<AlbumFileJoin>(
                l => l.HasOne<File>().WithMany().HasForeignKey("FileId").OnDelete(DeleteBehavior.NoAction),
                r => r.HasOne<Album>().WithMany().HasForeignKey("AlbumId").OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.HasKey(entity => new { entity.AlbumId, entity.FileId });
                    j.ToTable("AlbumsFiles");
                });
        builder
             .HasMany(album => album.Rating)
             .WithOne(rating => rating.Parent);
        builder
            .HasOne(album => (UserEntity)album.User)
            .WithMany(user => user.Albums)
            .HasForeignKey(post => post.UserId);
        
        builder.ToTable("Albums");
    }
}