using CLDVwebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CLDVwebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Preventing double bookings
            modelBuilder.Entity<Booking>()
                .HasIndex(b => new { b.VenueId, b.EventId })
                .IsUnique();
        }
    }
}
