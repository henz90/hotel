using hotel.Models;
using hotel.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace hotel.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }
        
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