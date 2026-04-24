using System.ComponentModel.DataAnnotations;

namespace EventHub.Models
{
    // Data Annotations
    // One-to-One => Organizer–Profile
    
    public class OrganizerProfile
    {
        [Key]
        public int OrganizerId { get; set; }

        public string Bio { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }

        public Organizer Organizer { get; set; }
    }
}
