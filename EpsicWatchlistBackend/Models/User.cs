using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicWatchlistBackend.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string Passconf { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserMovie> Movies { get; set; }
    }

    public class UserUpdateViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Passconf { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserCheckPasswordViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
