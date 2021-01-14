using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> Movies { get; set; }
    }
}
