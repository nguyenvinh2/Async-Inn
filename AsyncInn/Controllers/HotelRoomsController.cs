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
  public class HotelRoomsController : Controller
  {
    private readonly IHotelRooms _hotelRoom;
    private readonly IRooms _room;
    private readonly IHotels _hotel;

    public HotelRoomsController(IHotelRooms HotelRooms, IRooms Room, IHotels Hotel)
    {
      _hotelRoom = HotelRooms;
      _room = Room;
      _hotel = Hotel;
    }

    // GET: HotelRooms
    public async Task<IActionResult> Index()
    {
      return View(await _hotelRoom.GetHotelRooms());
    }

    // GET: HotelRooms/Details/5
    public async Task<IActionResult> Details(int? id, int? id2)
    {
      if (id == null & id2 == null)
      {
        return NotFound();
      }

      var hotelRoom = await _hotelRoom.GetHotelRoom(id, id2);
      if (hotelRoom == null)
      {
        return NotFound();
      }

      return View(hotelRoom);
    }

    // GET: HotelRooms/Create
    public async Task<IActionResult> Create()
    {
      ViewData["HotelID"] = new SelectList(await _hotel.GetHotels(), "ID", "Name");
      ViewData["RoomID"] = new SelectList(await _room.GetRooms(), "ID", "Name");
      return View();
    }

    // POST: HotelRooms/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
    {
        if (ModelState.IsValid)
        {
          await _hotelRoom.CreateHotelRooms(hotelRoom);
          return RedirectToAction(nameof(Index));
        }
        return View(hotelRoom);
    }

    // GET: HotelRooms/Edit/5
    public async Task<IActionResult> Edit(int? id, int? id2)
    {
      if (id == null || id2 == null)
      {
        return NotFound();
      }

      var hotelRoom = await _hotelRoom.GetHotelRoom(id, id2);
      if (hotelRoom == null)
      {
        return NotFound();
      }
      return View(hotelRoom);
    }

    // POST: HotelRooms/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int HotelID, int RoomID, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
    {
      if (HotelID != hotelRoom.HotelID || RoomID != hotelRoom.RoomID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _hotelRoom.UpdateHotelRooms(hotelRoom);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!HotelRoomExists(hotelRoom.HotelID, hotelRoom.RoomID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(hotelRoom);
    }

    // GET: HotelRooms/Delete/5
    public async Task<IActionResult> Delete(int? id, int? id2)
    {
      if (id == null || id2 == null)
      {
        return NotFound();
      }

      var hotelRoom = await _hotelRoom.GetHotelRoom(id, id2);
      if (hotelRoom == null)
      {
        return NotFound();
      }

      return View(hotelRoom);
    }

    // POST: HotelRooms/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int HotelID, int RoomID)
    {
      await _hotelRoom.DeleteHotelRooms(HotelID, RoomID);
      return RedirectToAction(nameof(Index));
    }

    private bool HotelRoomExists(int id, int id2)
    {
      return _hotelRoom.GetHotelRoom(id, id2) != null;
    }
  }
}
