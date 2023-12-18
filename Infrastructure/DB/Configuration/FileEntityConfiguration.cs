using Domain.Model;
using Domain.Model.Generic;
using Infrastructure.Identity.Entity;
using Infrastructure.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Configuration;

public class FileEntityConfiguration : IEntityTypeConfiguration<GenericFileEntity<int>>
{
    public void Configure(EntityTypeBuilder<GenericFileEntity<int>> builder)
    {
        builder.HasKey(file => file.Id);
        
        builder
            .HasOne(file => (UserEntity)file.User)
            .WithMany(user => user.Files)
            .HasForeignKey(file => file.UserId);
        builder.ToTable("Files");
    }
}