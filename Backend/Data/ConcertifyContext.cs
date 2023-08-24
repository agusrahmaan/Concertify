using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ConcertifyContext : DbContext
    {
        public ConcertifyContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
}
