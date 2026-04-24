using EventHub.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;


namespace EventHub.Data
{
    // DbContext

    public class AppDbContext : DbContext
    {
        // DbSet for each entity
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<EventRegistration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
             // Connection string configuration
            options.UseSqlServer("Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Config Classes
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new RegistrationConfig());

            #region Organizer-Profile

            // Organizer 1-1 Profile
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);

            #endregion

            #region Attendee-Address

            // Attendee Owned Address
            modelBuilder.Entity<Attendee>()
                .OwnsOne(a => a.Address);

            #endregion

            #region Attendee-Badge

            // Attendee 1-1 Badge
            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Badge)
                .WithOne(b => b.Attendee)
                .HasForeignKey<Badge>(b => b.AttendeeId);

            #endregion

            #region Event-Organizer

            // Event - Organizer
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId);

            #endregion


        }
    }
}
