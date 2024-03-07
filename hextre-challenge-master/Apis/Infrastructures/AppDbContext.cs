using Domain.Entities;
using Infrastructures.FluentAPIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder
                .Entity<Party>()
                .Property(p => p.AdditionalCost)
                .HasColumnType("decimal(18,2)");
            modelBuilder
                .Entity<Party>()
                .Property(p => p.DefaultCost)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Party>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Package>().Property(p => p.Price).HasColumnType("decimal(18,2)");

            modelBuilder.ApplyConfiguration(new PartyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
        }
    }
}
