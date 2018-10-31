using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IRooms
  {
    // Creating
    Task CreateRooms(Room Room);

    // updating
    Task UpdateRooms(Room room);

    //deleting
    Task DeleteRooms(int id);

    // Read
    Task<List<Room>> GetRooms();

    Task<Room> GetRoom(int? id);

  }
}
