using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotels
  {
    // Creating
    Task CreateHotels(Hotel Hotel);

    // updating
    Task UpdateHotels(Hotel Hotel);

    //deleting
    Task DeleteHotels(int id);

    // Read
    Task<List<Hotel>> GetHotels();

    Task<Hotel> GetHotel(int? id);
  }
}
