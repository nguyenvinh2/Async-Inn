using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
  public class RoomServices : IRooms
  {
    private AsyncInnDbContext _context;
    public RoomServices(AsyncInnDbContext context)
    {
      _context = context;
    }
    public async Task CreateRooms(Room Room)
    {
      _context.Rooms.Add(Room);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteRooms(int id)
    {
      Room Room = await GetRoom(id);
      _context.Rooms.Remove(Room);
      await _context.SaveChangesAsync();
    }

    public async Task<Room> GetRoom(int? id)
    {
      return await _context.Rooms.FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<List<Room>> GetRooms()
    {
      return await _context.Rooms.ToListAsync();
    }

    public async Task UpdateRooms(Room Room)
    {
      _context.Rooms.Update(Room);
      await _context.SaveChangesAsync();
    }
  }
}
