using EpsicWatchlistBackend.Models;
using System.Collections.Generic;

namespace EpsicWatchlistBackend.Services
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetSingle(int id);
        Movie Add(Movie movie);
        Movie Update(int id, MovieUpdateViewModel model);
        void Delete(int id);
        bool ExistsById(int id);
    }
}
