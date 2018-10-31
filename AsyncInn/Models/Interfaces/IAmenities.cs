using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenities
    {
    // Creating
    Task CreateAmenities(Amenity Amenity);

    // updating
    Task UpdateAmenities(Amenity Aminity);

    //deleting
    Task DeleteAmenities(int id);

    // Read
    Task<List<Amenity>> GetAmenities();

    Task<Amenity> GetAmenity(int? id);
  }
}
