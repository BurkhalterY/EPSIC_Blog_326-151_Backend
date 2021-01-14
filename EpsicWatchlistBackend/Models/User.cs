using System.Collections.Generic;

namespace EpsicWatchlistBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Is_admin { get; set; }
        public List<UserMovie> Movies { get; set; }
    }
}
