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
    [Required]
    [Display(Name = "Room Name")]
    public string Name { get; set; }
    [Required]
    [EnumDataType(typeof(Layout))]
    public Layout Layout { get; set; }
    public ICollection<RoomAmenity> RoomAmenities { get; set; }
    public ICollection<HotelRoom> HotelRooms { get; set; }
  }

  public enum Layout
  {
    Studio,
    [Display(Name = "One Bedroom")]
    OneBedroom,
    [Display(Name = "Two Name")]
    TwoBedroom
  }
}
