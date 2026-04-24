
namespace EventHub.Models
{
    public enum BadgeTier { Standard, VIP }

    // Separate Config via Fluent API
    // One-to-One => Attendee–Badge

    public class Badge
    {
        public int Id { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }

        public string BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }

        public BadgeTier Tier { get; set; }
    }
}
