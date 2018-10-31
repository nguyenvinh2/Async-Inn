using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsyncInn.Models.Interfaces
{
  public interface IRoomAmenities
  {
    // Creating
    Task CreateRoomAmenities(RoomAmenity RoomAmenity);

    //deleting
    Task DeleteRoomAmenities(int id, int id2);

    // Read
    Task<List<RoomAmenity>> GetRoomAmenities();

    Task<RoomAmenity> GetRoomAmenity(int? id, int? id2);


  }
}
