using hotel.Models;
using hotel.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace hotel.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<Room> Room { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=app.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbConfiguration());
        }
    }
}