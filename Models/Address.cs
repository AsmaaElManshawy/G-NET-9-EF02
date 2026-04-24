
namespace EventHub.Models
{
    // Owned Entity
    // No separate table, stored in Attendee table

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
