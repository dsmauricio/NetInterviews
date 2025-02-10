using Microsoft.AspNetCore.Mvc;
using NetInterviews.Business.Services;
using NetInterviews.Core.DTO;

namespace NetInterviews.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieService.GetById(id);
            if (movie is null)
            {
                return NotFound($"Movie : {id}");
            }

            return Ok(movie);
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            var movie = await _movieService.GetAll();
            return Ok(movie);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(MovieRequest movie)
        {
            var movieResponse = await _movieService.Add(movie);
            _logger.LogDebug($"Movie Created {movieResponse.Id}.");
            return Created($"/{movieResponse.Id}", movieResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MovieRequest Movie)
        {
            var movieResponse = await _movieService.Update(id, Movie);
            if (movieResponse is null)
            {
                return NotFound($"Movie {id}");
            }
            _logger.LogDebug($"Movie Updated {id}");
            return Ok(movieResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.Delete(id);
            _logger.LogDebug($"Movie Deleted {id}");
            return Ok();
        }

    }
}
