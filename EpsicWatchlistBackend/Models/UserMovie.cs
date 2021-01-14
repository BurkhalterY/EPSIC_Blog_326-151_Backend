using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class UserMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
