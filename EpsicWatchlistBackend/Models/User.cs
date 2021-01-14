using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserMovie> Movies { get; set; }
    }

    public class UserUpdateViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
