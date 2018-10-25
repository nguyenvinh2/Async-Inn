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
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public ICollection<HotelRoom> HotelRooms { get; set; }
  }
}
