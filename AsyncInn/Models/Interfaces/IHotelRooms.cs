using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotelRooms 
  {
    // Creating
    Task CreateHotelRooms (HotelRoom HotelRoom);

    // updating
    Task UpdateHotelRooms(HotelRoom HotelRoom);

    //deleting
    Task DeleteHotelRooms(int id, int id2);

    // Read
    Task<List<HotelRoom>> GetHotelRooms();

    Task<HotelRoom> GetHotelRoom(int? id, int? id2);
  }
}
