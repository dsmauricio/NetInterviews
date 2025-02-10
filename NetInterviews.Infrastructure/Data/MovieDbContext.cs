using Microsoft.EntityFrameworkCore;

using NetInterviews.Core.Models;
using NetInterviews.Infrastructure.Data.Config;

namespace NetInterviews.Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Movie>(new MovieConfiguration());
        }

        public bool HasChanges()
        {
            var hasChanges = ChangeTracker.Entries().Any(e =>
                e.State == EntityState.Added || 
                e.State == EntityState.Modified || 
                e.State == EntityState.Deleted
            );

            return hasChanges;
        }

    }
}
