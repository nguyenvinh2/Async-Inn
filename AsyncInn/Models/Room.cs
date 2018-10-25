using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Room
  {
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public Layout Layout { get; set; }
    public int Age { get; set; }

    public ICollection<RoomAmenity> RoomAmenities { get; set; }
    public ICollection<HotelRoom> HotelRooms { get; set; }
  }

  public enum Layout
  {
    Studio,
    OneBedroom,
    TwoBedroom
  }
}
