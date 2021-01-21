using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public List<UserMovie> Users { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }

    public class MovieUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
    }
}
