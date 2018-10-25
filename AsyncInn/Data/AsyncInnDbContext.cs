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
		}

		public DbSet<Room> Rooms { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
  }
}
