using CLDVwebApp.Data;
using CLDVwebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDVwebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display all bookings
        public IActionResult Index()
        {
            var bookings = _context.Bookings
                .Include(b => b.Venue) // Include venue details for each booking
                .Include(b => b.Event) // Include event details for each booking
                .ToList(); // Fetch all bookings from DB
            return View(bookings); // Pass bookings to the view
        }

        // Action to create a new booking
        public IActionResult Create()
        {
            // Populate ViewData with venues and events for dropdowns or selection
            ViewData["Venues"] = _context.Venues.ToList();
            ViewData["Events"] = _context.Events.ToList();

            return View();
        }

        // Action to save the new booking
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Check if the venue is already booked for the selected event date
                var existingBooking = _context.Bookings
                    .Any(b => b.VenueId == booking.VenueId && b.EventDate == booking.EventDate);

                if (existingBooking)
                {
                    ModelState.AddModelError(string.Empty, "This venue is already booked for the selected date.");
                    ViewData["Venues"] = _context.Venues.ToList();
                    ViewData["Events"] = _context.Events.ToList();
                    return View(booking); // Show error message and stay on the create view
                }

                _context.Add(booking); // Add the booking to the database
                _context.SaveChanges(); // Save the changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the Index action (booking list)
            }

            // If the model is not valid, return the same view with errors
            ViewData["Venues"] = _context.Venues.ToList();
            ViewData["Events"] = _context.Events.ToList();
            return View(booking);
        }

        // Action to edit an existing booking
        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings.Find(id); // Fetch the booking to edit
            if (booking == null)
            {
                return NotFound(); // If booking not found, return 404
            }

            // Populate ViewData with venues and events for dropdowns or selection
            ViewData["Venues"] = _context.Venues.ToList();
            ViewData["Events"] = _context.Events.ToList();
            return View(booking); // Pass the booking to the edit view
        }

        // Action to save the updated booking
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Check if the venue is already booked for the selected event date
                var existingBooking = _context.Bookings
                    .Any(b => b.VenueId == booking.VenueId && b.EventDate == booking.EventDate && b.BookingId != booking.BookingId);

                if (existingBooking)
                {
                    ModelState.AddModelError(string.Empty, "This venue is already booked for the selected date.");
                    ViewData["Venues"] = _context.Venues.ToList();
                    ViewData["Events"] = _context.Events.ToList();
                    return View(booking); // Show error message and stay on the edit view
                }

                _context.Update(booking); // Update the booking in the database
                _context.SaveChanges(); // Save the changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the Index action (booking list)
            }

            // If the model is not valid, return the same view with errors
            ViewData["Venues"] = _context.Venues.ToList();
            ViewData["Events"] = _context.Events.ToList();
            return View(booking);
        }

        // Action to delete a booking
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id); // Find the booking to delete
            if (booking == null)
            {
                return NotFound(); // If booking not found, return 404
            }
            return View(booking); // Pass the booking to the delete view
        }

        // Action to confirm deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Bookings.Find(id); // Find the booking to delete
            _context.Bookings.Remove(booking); // Remove the booking from the DB
            _context.SaveChanges(); // Save the changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the Index action (booking list)
        }
    }
}
