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
  public class RoomAmenitiesServices : IRoomAmenities
  {
    private AsyncInnDbContext _context;
    public RoomAmenitiesServices(AsyncInnDbContext context)
    {
      _context = context;
    }
    public async Task CreateRoomAmenities(RoomAmenity RoomAmenity)
    {
      _context.Add(RoomAmenity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteRoomAmenities(int id, int id2)
    {
      var roomAmenity = await _context.RoomAmenities.FindAsync(id2, id);
      _context.RoomAmenities.Remove(roomAmenity);
      await _context.SaveChangesAsync();
    }

    public async Task<RoomAmenity> GetRoomAmenity(int? id, int? id2)
    {
      return await _context.RoomAmenities
          .Include(r => r.Room)
          .Include(r => r.Amenity)
          .FirstOrDefaultAsync(r => r.RoomID == id2 && r.AmenityID == id);
    }

    public async Task<List<RoomAmenity>> GetRoomAmenities()
    {
      var roomAmenityDbContext = _context.RoomAmenities.Include(c => c.Room).Include(c => c.Amenity);
      return await roomAmenityDbContext.ToListAsync();
    }
  }
}
