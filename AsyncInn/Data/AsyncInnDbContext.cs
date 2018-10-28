using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;

namespace AsyncInn.Data
{
  public class AsyncInnDbContext : DbContext
  {
    public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<RoomAmenity>().HasKey(
        ra => new { ra.AmenityID, ra.RoomID }
      );
      modelBuilder.Entity<HotelRoom>().HasKey(
        hr => new { hr.HotelID, hr.RoomID }
      );

      modelBuilder.Entity<Room>().HasData(
        new Room
        {
          ID = 1,
          Name = "Kite",
          Layout = Layout.OneBedroom,
        },
        new Room
        {
          ID = 2,
          Name = "Punny",
          Layout = Layout.Studio,
        },
        new Room
        {
          ID = 3,
          Name = "Miner",
          Layout = Layout.TwoBedroom,
        },
        new Room
        {
          ID = 4,
          Name = "Bursers",
          Layout = Layout.OneBedroom,
        },
        new Room
        {
          ID = 5,
          Name = "Coraline",
          Layout = Layout.Studio,
        },
        new Room
        {
          ID = 6,
          Name = "Pop",
          Layout = Layout.TwoBedroom,
        }
      );
      modelBuilder.Entity<Hotel>().HasData(
        new Hotel
        {
          ID = 1,
          Name = "Hilten",
          Address = "123 Fake Street",
          Phone = "205-434-5684"
        },
        new Hotel
        {
          ID = 2,
          Name = "Sheratone",
          Address = "538 Numpy Street",
          Phone = "352-569-3862"
        },
        new Hotel
        {
          ID = 3,
          Name = "Westen",
          Address = "321 Scipy Street",
          Phone = "235-234-6621"
        },
        new Hotel
        {
          ID = 4,
          Name = "Hiatte",
          Address = "959 C-Flat Street",
          Phone = "385-375-2385"
        },
        new Hotel
        {
          ID = 5,
          Name = "Four Quarters",
          Address = "235 Java Street",
          Phone = "238-498-3235"
        }
      );
      modelBuilder.Entity<Amenity>().HasData(
        new Amenity
        {
          ID = 1,
          Name = "Jacuzzi"
        },
        new Amenity
        {
          ID = 2,
          Name = "Ocean View"
        },
        new Amenity
        {
          ID = 3,
          Name = "Mini Bar"
        },
        new Amenity
        {
          ID = 4,
          Name = "Satellite Television"
        },
        new Amenity
        {
          ID = 5,
          Name = "Skylight"
        }
      );
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
  }
}
