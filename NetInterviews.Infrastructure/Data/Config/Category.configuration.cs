using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NetInterviews.Core.Models;

namespace NetInterviews.Infrastructure.Data.Config;

public partial class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired();

        builder.HasMany(c => c.Movies).WithOne(op => op.Category).HasForeignKey("CategoryId").IsRequired(true);

        builder.HasData(
            new Category { Id = 1, Name = "Action"},
            new Category { Id = 2, Name = "Adventure"},
            new Category { Id = 3, Name = "Horror"},
            new Category { Id = 4, Name = "Thriller"},
            new Category { Id = 5, Name = "Comedy" }
        );

    }
}

