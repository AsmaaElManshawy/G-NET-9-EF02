
namespace EventHub.Models
{
    // Fluent API via Config Class
    // Self-referencing for Event Sessions
    // Many-to-Many => Attendee–Event with extra data via EventRegistration

    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public int? ParentEventId { get; set; }
        public Event ParentEvent { get; set; }

        public ICollection<Event> Sessions { get; set; }
        public ICollection<EventRegistration> Registrations { get; set; }

        // Shadow properties will be configured (CreatedAt, UpdatedAt)
    }
}
