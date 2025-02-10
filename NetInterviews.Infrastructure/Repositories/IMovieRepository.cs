using NetInterviews.Core.Enums;
using NetInterviews.Core.Models;

namespace NetInterviews.Infrastructure.Repositories;

public interface IMovieRepository
{
    Task<Movie?> GetById(int id);
    Task<IEnumerable<Movie>> GetAll();
    Task<Movie> Create(string title, Ratings rating, bool seen, int categoryId);
    Task<Movie?> Update(int id, string title, Ratings rating, bool seen, int categoryId);
    Task Delete(int id);
}