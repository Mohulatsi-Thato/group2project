using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLDVwebApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }  // ✅ Use only this

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }  // ✅ Foreign key for Event

        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }  // ✅ Foreign key for Venue

        [Required]
        public DateTime EventDate { get; set; } = DateTime.Now; // ✅ Ensure correct type

        public Event Event { get; set; } // ✅ Navigation property
        public Venue Venue { get; set; } // ✅ Navigation property
    }
}