using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Thiết lập quan hệ n-1 với bảng User (Host)
            builder.HasOne(p => p.Host)
                   .WithMany(u => u.Parties)
                   .HasForeignKey(p => p.HostID);

            // Thiết lập quan hệ 1-n với bảng Package
            builder.HasOne(p => p.Package)
                   .WithMany()
                   .HasForeignKey(p => p.PackageID);

            // Thiết lập quan hệ 1-n với bảng Venue
            builder.HasOne(p => p.Venue)
                   .WithMany()
                   .HasForeignKey(p => p.VenueID);
        }
    }
}