using Domain.Model;
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
            .WithOne(reaction => reaction.Parent)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasMany(post => post.Comments)
            .WithOne(comment => comment.Post)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(post => (UserEntity)post.User)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.UserId);
        builder.Property(p => p.Status);
        
        // z powodu użycia konwersji EF nie jest w stanie przekonwertować LINQ na zapytanie bazodanowe,
        // potrzebne jest wiec rozwiazanie naprawiajace ten problem
        // poniższe rozwiazanie oszukuje silnik EF rzutująć obiekt STATUSFIELD na obiekt a następnie na string'a
        // wynik takiego rozwiązania tworzy następujące zapytanie - WHERE CAST([p].[Status] AS nvarchar(max)) LIKE N'%1%'
        // https://stackoverflow.com/questions/63856189/can-ef-core-invoke-methods-in-queries-against-properties-which-have-conversions
        // builder.HasQueryFilter(p => ((string)(object)p.StatusField).Contains(((int)StatusEnum.Visible).ToString())); 
        
        // builder.HasQueryFilter(p => p.Status == StatusEnum.Visible);
        
        builder.ToTable("Posts");
    }
}