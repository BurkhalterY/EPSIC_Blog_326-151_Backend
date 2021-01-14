using EpsicWatchlistBackend.Models;
using EpsicWatchlistBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpsicWatchlistBackend.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("movies")]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("movies/{id}")]
        public IActionResult GetSingle(int id)
        {
            if (id <= 0) return BadRequest();
            var movie = _movieService.GetSingle(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost("movies/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieUpdateViewModel model)
        {
            if (id <= 0) return BadRequest();
            if (!_movieService.ExistsById(id)) return NotFound();
            return Ok(_movieService.Update(id, model));
        }

        [HttpPost("movies")]
        public IActionResult Add(Movie movie)
        {
            if (_movieService.ExistsById(movie.Id)) return BadRequest();
            _movieService.Add(movie);
            return Created($"movies/{movie.Id}", movie);
        }

        [HttpDelete("movies/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
