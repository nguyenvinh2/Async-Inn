using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
  public class RoomAmenity
  {
    [Display(Name = "Amenity")]
    public int AmenityID { get; set; }
    [Display(Name = "Room")]
    public int RoomID { get; set; }
    public Amenity Amenity { get; set; }
    public Room Room { get; set; }
  }
}
