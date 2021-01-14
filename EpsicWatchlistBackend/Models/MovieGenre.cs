using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class MovieGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
