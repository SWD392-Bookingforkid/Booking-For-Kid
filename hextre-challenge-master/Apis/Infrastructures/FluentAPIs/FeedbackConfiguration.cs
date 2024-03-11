using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasOne(f => f.Customer)
                   .WithOne(c => c.Feedback)
                   .HasForeignKey<Feedback>(f => f.CustomerID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Party)
                   .WithOne(p => p.Feedback)
                   .HasForeignKey<Feedback>(f => f.PartyID)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}