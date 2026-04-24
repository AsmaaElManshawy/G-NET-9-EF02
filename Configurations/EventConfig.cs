using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations
{
    // Fluent API for Event entity
    // Configures properties, relationships, and shadow properties for Event

    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(200);

            builder.HasOne(e => e.ParentEvent)
                   .WithMany(e => e.Sessions)
                   .HasForeignKey(e => e.ParentEventId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Shadow Properties
            builder.Property<DateTime>("CreatedAt")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property<DateTime>("UpdatedAt");
        }
    }
}
