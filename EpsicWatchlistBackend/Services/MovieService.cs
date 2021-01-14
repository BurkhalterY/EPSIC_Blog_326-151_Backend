using EpsicWatchlistBackend.Data;
using EpsicWatchlistBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace EpsicWatchlistBackend.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDataContext _context;

        public MovieService(WatchlistDataContext context)
        {
            _context = context;
        }

        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public void Delete(int id)
        {
            _context.Movies.Remove(GetSingle(id));
            _context.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetSingle(int id)
        {
            return _context.Movies.FirstOrDefault(e => e.Id == id);
        }

        public Movie Update(int id, MovieUpdateViewModel model)
        {
            var movie = GetSingle(id);

            movie.Title = model.Title;
            movie.Year = model.Year;
            movie.Duration = model.Duration;
            movie.Image = model.Image;

            _context.SaveChanges();
            return movie;
        }
    }
}
