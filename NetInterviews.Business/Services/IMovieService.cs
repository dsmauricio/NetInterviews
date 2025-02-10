using NetInterviews.Core.DTO;

namespace NetInterviews.Business.Services;

public interface IMovieService
{
    Task<MovieResponse> Add(MovieRequest movieRequest);
    Task<MovieResponse?> Update(int id, MovieRequest movieRequest);
    Task Delete(int id);
    Task<MovieResponse?> GetById(int id);
    Task<IEnumerable<MovieResponse>> GetAll();
}