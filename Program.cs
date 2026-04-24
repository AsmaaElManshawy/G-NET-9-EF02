using EventHub.Data;
using EventHub.Models;

namespace EventHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ensure database is created and seed initial data
            using var context = new AppDbContext();

            context.Database.EnsureCreated();
            // Seed initial data for testing 
            // Create an organizer with profile and an event
            var organizer = new Organizer
            {
                Name = "Tech Corp",
                IsVerified = true,
                Profile = new OrganizerProfile
                {
                    Bio = "Tech Events Organizer",
                    Website = "https://tech.com",
                    LogoUrl = "https://share.google/H83zNSWLebGGpvc0V"
                }
            };
            
            context.Organizers.Add(organizer);
            context.SaveChanges();

            // Create an event for the organizer
            var ev = new Event
            {
                Title = "AI Conference",
                Description = "Future of AI",
                StartDate = DateTime.Now,
                OrganizerId = organizer.Id
            };

            context.Events.Add(ev);
            context.SaveChanges();

            Console.WriteLine("Database Created & Seeded!");
        }
    }
}
