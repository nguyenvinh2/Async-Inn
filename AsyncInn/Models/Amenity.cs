using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Amenity
  {
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }

    public ICollection<RoomAmenity> RoomAmenities { get; set; }
  }
}
