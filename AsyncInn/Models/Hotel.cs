using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Hotel
  {
    [Key]
    public int ID { get; set; }
    [Required]
    [Display(Name = "Hotel Name")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Address")]
    public string Address { get; set; }
    [Required]
    [Display(Name = "Phone Number")]
    public string Phone { get; set; }

    public ICollection<HotelRoom> HotelRooms { get; set; }
  }
}
