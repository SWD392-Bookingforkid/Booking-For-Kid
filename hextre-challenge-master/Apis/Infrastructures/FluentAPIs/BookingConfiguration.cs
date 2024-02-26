using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Thiết lập quan hệ n-1 với bảng User (Guest)
            builder.HasOne(b => b.Guest)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.GuestID)
                   .OnDelete(DeleteBehavior.NoAction);

            // Thiết lập quan hệ n-1 với bảng Party
            builder.HasOne(b => b.Party)
                   .WithOne(p => p.Booking)
                   .HasForeignKey<Booking>(b => b.PartyID)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}