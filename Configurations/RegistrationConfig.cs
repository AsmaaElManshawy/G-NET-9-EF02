using EventHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations
{
    // Fluent API for EventRegistration (Many-to-Many with extra data)
    public class RegistrationConfig : IEntityTypeConfiguration<EventRegistration>
    {
        public void Configure(EntityTypeBuilder<EventRegistration> builder)
        {
            builder.HasKey(r => new { r.AttendeeId, r.EventId });

            builder.Property(r => r.RegisteredAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
