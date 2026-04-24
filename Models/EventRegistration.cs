
namespace EventHub.Models
{
    // Attendee–Event => Many-to-Many with extra data

    public class EventRegistration
    {
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string? Note { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
