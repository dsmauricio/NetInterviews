using Microsoft.EntityFrameworkCore;
using NetInterviews.Core.Enums;
using NetInterviews.Core.Models;
using NetInterviews.Infrastructure.Data;

namespace NetInterviews.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _db;
    public MovieRepository(MovieDbContext db)
    {
        _db = db;
    }


    public async Task<Movie?> GetById(int id)
    {
        var movie = await _db.Movies.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAll()
    {
        var movies = await _db.Movies.Include(c => c.Category).ToListAsync();
        return movies;
    }

    public async Task<Movie> Create(string title, Ratings rating, bool seen, int categoryId)
    {
        var movie = new Movie()
        {
            Title = title,
            Rating = rating,
            Seen = seen,
            CategoryId = categoryId
        };

        _db.Movies.Add(movie);
        await _db.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie?> Update(int id, string title, Ratings rating, bool seen, int categoryId)
    {
        var movie = await _db.Movies.FindAsync(id);
        if (movie is not null)
        {
            movie.Title = title;
            movie.Rating = rating;
            movie.Seen = seen;
            movie.CategoryId = categoryId;
            await _db.SaveChangesAsync();
            return movie;
        }

        return null;
    }

    public async Task Delete(int id)
    {
        var movie = await _db.Movies.FindAsync(id);
        if (movie is not null)
        {
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }
    }


}
