using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpsicBlogBackend.Models
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
        public byte[] Avatar { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
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
