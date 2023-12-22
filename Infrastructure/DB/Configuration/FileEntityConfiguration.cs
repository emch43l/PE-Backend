using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Infrastructure.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Domain.Model.Generic.File;

namespace Infrastructure.DB.Configuration;

public class FileEntityConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasKey(file => file.Id);
        
        builder
            .HasOne(file => (UserEntity)file.User)
            .WithMany(user => user.Files)
            .HasForeignKey(file => file.UserId);
        builder.ToTable("Files");
    }
}