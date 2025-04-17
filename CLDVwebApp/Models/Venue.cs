using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace CLDVwebApp.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        public string VenueName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
