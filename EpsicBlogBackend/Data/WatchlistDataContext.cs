using EpsicBlogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EpsicBlogBackend.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options)
        {

        }
    }
}
