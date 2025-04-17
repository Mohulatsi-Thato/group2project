using CLDVwebApp.Data;
using CLDVwebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDVwebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Event List
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.Include(e => e.Venue).ToListAsync();
            return View(events);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }
    }
}
