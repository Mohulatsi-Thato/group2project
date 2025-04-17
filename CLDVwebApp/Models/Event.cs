using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLDVwebApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        [ForeignKey("Venue")]
        public int? VenueId { get; set; }

        public Venue Venue { get; set; }
    }
}
