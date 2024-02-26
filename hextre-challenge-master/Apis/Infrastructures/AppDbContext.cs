using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Party>().Property(p => p.AdditionalCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Party>().Property(p => p.DefaultCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Party>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Package>().Property(p => p.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Party>()
                .HasOne(p => p.Host)
                .WithMany(u => u.Parties)
                .HasForeignKey(p => p.HostID);


            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.GuestID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Party)
                .WithOne(p => p.Booking)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
