using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class HotelRoom
  {
    [Display(Name = "Hotel")]
    public int HotelID { get; set; }
    [Required]
    [Display(Name = "Room Number")]
    public int RoomNumber { get; set; }
    [Display(Name = "Room")]
    public int RoomID { get; set; }
    [Required]
    [Display(Name = "Price")]
    public decimal Rate { get; set; }
    [Required]
    [Display(Name = "Pet Friendly")]
    public bool PetFriendly { get; set; }

    public Room Room { get; set; }
    public Hotel Hotel { get; set; }
  }
}
