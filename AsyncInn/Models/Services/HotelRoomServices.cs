using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsyncInn.Models.Services
{
  public class HotelRoomServices : IHotelRooms
  {
    private AsyncInnDbContext _context;
    public HotelRoomServices(AsyncInnDbContext context)
    {
      _context = context;
    }
    public async Task CreateHotelRooms(HotelRoom HotelRoom)
    {
      _context.Add(HotelRoom);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteHotelRooms(int id, int id2)
    {
      var hotelRoom = await _context.HotelRooms.FindAsync(id, id2);
      _context.HotelRooms.Remove(hotelRoom);
      await _context.SaveChangesAsync();
    }

    public async Task<HotelRoom> GetHotelRoom(int? id, int? id2)
    {
      return await _context.HotelRooms
          .Include(r => r.Hotel)
          .Include(r => r.Room)
          .FirstOrDefaultAsync(r => r.HotelID == id && r.RoomID == id2);
    }

    public async Task<List<HotelRoom>> GetHotelRooms()
    {
      var hotelRoomDbContext = _context.HotelRooms.Include(c => c.Room).Include(c => c.Hotel);

      return await hotelRoomDbContext.ToListAsync();
    }

    public async Task UpdateHotelRooms(HotelRoom hotelRoom)
    {
      _context.Update(hotelRoom);
      await _context.SaveChangesAsync();
    }
  }
}
