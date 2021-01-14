using EpsicWatchlistBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EpsicWatchlistBackend.Data
{
    public class WatchlistDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WatchlistDataContext(DbContextOptions<WatchlistDataContext> options) : base(options)
        {

        }
    }
}
