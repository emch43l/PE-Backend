using Domain.Model;
using Infrastructure.Identity.Entity.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class FileEntityConfiguration : IEntityTypeConfiguration<FileEntity<int>>
{
    public void Configure(EntityTypeBuilder<FileEntity<int>> builder)
    {
        builder.HasKey(file => file.Id);
        builder
            .HasOne(file => file.Post)
            .WithMany(post => post.Files)
            .HasForeignKey("PostId");
        builder
            .HasOne(file => file.Comment)
            .WithOne(comment => comment.File)
            .HasForeignKey("CommentId");
        builder
            .HasMany(file => file.Albums)
            .WithMany(album => album.Files)
            .UsingEntity<AlbumFileJoin<int>>(
                albumFile => albumFile.ToTable("AlbumsFiles")
            );
        builder.ToTable("Files");
    }
}