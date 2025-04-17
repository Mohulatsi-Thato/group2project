using CLDVwebApp.Data;
using CLDVwebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVwebApp.Controllers
{
    public class VenueController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public VenueController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display all venues
        public IActionResult Index()
        {
            var venues = _context.Venues.ToList(); // Fetch all venues from DB
            return View(venues); // Pass venues to the view
        }

        // Action to create a new venue
        public IActionResult Create()
        {
            return View();
        }

        // Action to save the new venue
        [HttpPost]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(venue); // Return the view with validation errors
        }

        // Action to edit an existing venue
        public IActionResult Edit(int id)
        {
            var venue = _context.Venues.Find(id); // Fetch the venue to edit
            if (venue == null)
            {
                return NotFound(); // If venue not found, return 404
            }
            return View(venue); // Pass the venue to the edit view
        }

        // Action to save the updated venue
        [HttpPost]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Update(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(venue); // Return the view with validation errors
        }

        // Action to delete a venue
        public IActionResult Delete(int id)
        {
            var venue = _context.Venues.Find(id); // Find the venue to delete
            if (venue == null)
            {
                return NotFound(); // If venue not found, return 404
            }
            return View(venue); // Pass the venue to the delete view
        }

        // Action to confirm deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var venue = _context.Venues.Find(id); // Find the venue to delete
            _context.Venues.Remove(venue); // Remove the venue from the DB
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }
    }
}
