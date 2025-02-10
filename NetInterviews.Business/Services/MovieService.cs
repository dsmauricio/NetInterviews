using NetInterviews.Core.DTO;
using NetInterviews.Infrastructure.Repositories;

namespace NetInterviews.Business.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieResponse> Add(MovieRequest movieRequest)
    {
        var movie = await _movieRepository.Create(movieRequest.Title, movieRequest.Rating, movieRequest.Seen, movieRequest.CategoryId );
        
        var movieResponse = new MovieResponse()
        {
            Id = movie.Id, 
            Title = movie.Title, 
            Rating = movie.Rating, 
            Seen = movie.Seen, 
            CategoryId = movie.CategoryId
//             Category = new CategoryResponse() { Id = movie.Category.Id, Name = movie.Category.Name }
        };
        return movieResponse;
    }

    public async Task<MovieResponse?> Update(int id, MovieRequest movieRequest)
    {
        var movie = await _movieRepository.Update(id, movieRequest.Title, movieRequest.Rating, movieRequest.Seen, movieRequest.CategoryId);
        if (movie is null)
        {
            return null;
        }

        var movieResponse = new MovieResponse()
        {
            Id = movie.Id, 
            Title = movie.Title, 
            Rating = movie.Rating, 
            Seen = movie.Seen, 
            CategoryId = movie.CategoryId
//            Category = new CategoryResponse() {Id = movie.Category.Id, Name = movie.Category.Name}
        };
        return movieResponse;
    }

    public async Task Delete(int id)
    {
        await _movieRepository.Delete(id);
    }

    public async Task<MovieResponse?> GetById(int id)
    {
        var movie = await _movieRepository.GetById(id);
        if (movie is null)
        {
            return null;
        }

        var movieResponse = new MovieResponse()
        {
            Id = movie.Id,
            Title = movie.Title,
            Rating = movie.Rating,
            Seen = movie.Seen,
            CategoryId = movie.CategoryId,
            Category = new CategoryResponse() { Id = movie.Category.Id, Name = movie.Category.Name }
        }; 
        
        return movieResponse;
    }

    public async Task<IEnumerable<MovieResponse>> GetAll()
    {
        var movies = await _movieRepository.GetAll();

        var moviesResponse = movies.Select(c => new MovieResponse
        {
            Id = c.Id,
            Title = c.Title,
            Rating = c.Rating,
            Seen = c.Seen,
            CategoryId = c.Category.Id,
            Category = new CategoryResponse() { Id = c.Category.Id, Name = c.Category.Name }
        });

        return moviesResponse;
    }

}
