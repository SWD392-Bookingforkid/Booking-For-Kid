using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Thiết lập quan hệ nhiều-1 với bảng Role
            builder.HasOne(u => u.Role)
                   .WithMany()
                   .HasForeignKey(u => u.RoleID);

            // Thiết lập quan hệ 1-nhieu giữa User và Party
            builder.HasMany(u => u.Parties)
                   .WithOne(p => p.Host)
                   .HasForeignKey(p => p.HostID);

            // Thiết lập quan hệ 1-nhiều giữa User và Booking
            builder.HasMany(u => u.Bookings)
                   .WithOne(b => b.Guest)
                   .HasForeignKey(b => b.GuestID);
        }
    }
}
