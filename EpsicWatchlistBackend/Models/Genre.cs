using System.Collections.Generic;

namespace EpsicWatchlistBackend.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> Movies { get; set; }
    }
}
