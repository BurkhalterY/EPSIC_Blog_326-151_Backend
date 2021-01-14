using EpsicWatchlistBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EpsicWatchlistBackend.Data
{
    public class WatchlistDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public WatchlistDataContext(DbContextOptions<WatchlistDataContext> options) : base(options)
        {

        }
    }
}
