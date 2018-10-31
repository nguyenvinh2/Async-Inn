using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
  public class RoomAmenitiesController : Controller
  {
    private readonly IRoomAmenities _roomAmenities;
    private readonly IRooms _room;
    private readonly IAmenities _amenity;

    public RoomAmenitiesController(IRoomAmenities RoomAmenities, IRooms Room, IAmenities Amenity)
    {
      _roomAmenities = RoomAmenities;
      _room = Room;
      _amenity = Amenity;
    }

    // GET: RoomAmenities
    public async Task<IActionResult> Index()
    {
      return View(await _roomAmenities.GetRoomAmenities());
    }    

    // GET: RoomAmenities/Details/5
    public async Task<IActionResult> Details(int? id, int? id2)
    {
      if (id == null)
      {
        return NotFound();
      }

      var roomAmenity = await _roomAmenities.GetRoomAmenity(id, id2);
      if (roomAmenity == null)
      {
        return NotFound();
      }

      return View(roomAmenity);
    }

    // GET: RoomAmenities/Create
    public async Task<IActionResult> Create()
    {
      ViewData["AmenityID"] = new SelectList(await _amenity.GetAmenities(), "ID", "Name");
      ViewData["RoomID"] = new SelectList(await _room.GetRooms(), "ID", "Name");
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
        await _roomAmenities.CreateRoomAmenities(roomAmenity);
        return RedirectToAction(nameof(Index));
      }
      return View(roomAmenity);
    }

    // GET: RoomAmenities/Delete/5
    public async Task<IActionResult> Delete(int? id, int? id2)
    {
      if (id == null || id2 == null)
      {
        return NotFound();
      }

      var roomAmenity = await _roomAmenities.GetRoomAmenity(id, id2);
      if (roomAmenity == null)
      {
        return NotFound();
      }

      return View(roomAmenity);
    }

    // POST: RoomAmenities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int RoomID, int AmenityID)
    {
      await _roomAmenities.DeleteRoomAmenities(RoomID, AmenityID);
      return RedirectToAction(nameof(Index));
    }

    private bool RoomAmenityExists(int id, int id2)
    {
      return _roomAmenities.GetRoomAmenity(id, id2) != null;
    }
  }
}
