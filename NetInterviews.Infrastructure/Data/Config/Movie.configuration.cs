using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NetInterviews.Core.Enums;
using NetInterviews.Core.Models;

namespace NetInterviews.Infrastructure.Data.Config;

public partial class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.Title).IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.Rating).IsRequired().ValueGeneratedOnAdd();
        builder.Property(c => c.CategoryId).IsRequired().ValueGeneratedOnAdd();

        builder.HasOne(c => c.Category).WithMany(op => op.Movies).HasForeignKey("CategoryId").IsRequired(true);

        builder.HasData(
            new Movie { Id = 1, Title = "Interstellar", Rating = Ratings.R, Seen = false, CategoryId = 2 },
            new Movie { Id = 2, Title = "Mr Bean", Rating = Ratings.Pg, Seen = false, CategoryId = 5 },
            new Movie { Id = 3, Title = "Collateral", Rating = Ratings.R, Seen = false, CategoryId = 1 },
            new Movie { Id = 4, Title = "The Haunting", Rating = Ratings.R, Seen = false, CategoryId = 3 },
            new Movie { Id = 5, Title = "Don't move", Rating = Ratings.R, Seen = false, CategoryId = 4 }
        );

    }
}
