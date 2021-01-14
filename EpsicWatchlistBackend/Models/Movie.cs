using System.Collections.Generic;

namespace EpsicWatchlistBackend.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public List<UserMovie> Users { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }
}
