using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
  public class RoomAmenitiesController : Controller
  {
    private readonly AsyncInnDbContext _context;

    public RoomAmenitiesController(AsyncInnDbContext context)
    {
      _context = context;
    }

    // GET: RoomAmenities
    public async Task<IActionResult> Index()
    {
      var asyncInnDbContext = _context.RoomAmenities.Include(r => r.Amenity).Include(r => r.Room);
      return View(await asyncInnDbContext.ToListAsync());
    }

    // GET: RoomAmenities/Details/5
    public async Task<IActionResult> Details(int? id, int? id2)
    {
      if (id == null)
      {
        return NotFound();
      }

      var roomAmenity = await _context.RoomAmenities
          .Include(r => r.Amenity)
          .Include(r => r.Room)
          .FirstOrDefaultAsync(m => m.AmenityID == id && m.RoomID == id2);
      if (roomAmenity == null)
      {
        return NotFound();
      }

      return View(roomAmenity);
    }

    // GET: RoomAmenities/Create
    public IActionResult Create()
    {
      ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name");
      ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
      return View();
    }

    // POST: RoomAmenities/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AmenityID,RoomID")] RoomAmenity roomAmenity)
    {
      if (ModelState.IsValid)
      {
        _context.Add(roomAmenity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", roomAmenity.RoomID);
      ViewData["AmenityID"] = new SelectList(_context.Amenities, "ID", "Name", roomAmenity.AmenityID);
      return View(roomAmenity);
    }

    // GET: RoomAmenities/Delete/5
    public async Task<IActionResult> Delete(int? id, int? id2)
    {
      if (id == null || id2 == null)
      {
        return NotFound();
      }

      var roomAmenity = await _context.RoomAmenities
          .Include(r => r.Amenity)
          .Include(r => r.Room)
          .FirstOrDefaultAsync(m => m.AmenityID == id && m.RoomID == id2);
      if (roomAmenity == null)
      {
        return NotFound();
      }

      return View(roomAmenity);
    }

    // POST: RoomAmenities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, int id2)
    {
      var roomAmenity = await _context.RoomAmenities.FindAsync(id, id2);
      _context.RoomAmenities.Remove(roomAmenity);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool RoomAmenityExists(int id, int id2)
    {
      return _context.RoomAmenities.Any(e => e.AmenityID == id && e.RoomID == id2);
    }
  }
}
