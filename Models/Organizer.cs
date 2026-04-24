using System.ComponentModel.DataAnnotations;

namespace EventHub.Models
{
    // Data Annotations
    // One-to-Many => Organizer–Events
    // One-to-One => Organizer–Profile
    
    public class Organizer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        public OrganizerProfile Profile { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
