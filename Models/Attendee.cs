
namespace EventHub.Models
{
    // Fluent API inside DbContext
    // One-to-One => Attendee–Badge
    
    public class Attendee
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }

        public Badge Badge { get; set; }

        public ICollection<EventRegistration> Registrations { get; set; }
    }
}
