using System;
using Xunit;
using AsyncInn;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using System.Linq;

namespace XUnitTestAsyncInn
{
  public class UnitTest1
  {
    /// <summary>
    /// test if can access model property for hotels
    /// </summary>
    [Fact]
    public void GetHotelName()
    {
      Hotel hotel = new Hotel();
      hotel.Name = "MyHotel";

      Assert.Equal("MyHotel", hotel.Name);

    }
    /// <summary>
    /// test is can change model property for hotels
    /// </summary>
    [Fact]
    public void SetCourseName()
    {
      Hotel hotel = new Hotel();
      hotel.Name = "Potions";
      hotel.Name = "Python";
      Assert.Equal("Python", hotel.Name);
    }
    /// <summary>
    /// get room property
    /// </summary>
    [Fact]
    public void GetRoomName()
    {
      Room room = new Room();
      room.Name = "MyRoom";

      Assert.Equal("MyRoom", room.Name);

    }
    /// <summary>
    /// test is can change model property for rooms
    /// </summary>
    [Fact]
    public void SetRoomName()
    {
      Room room = new Room();
      room.Name = "Potions";
      room.Name = "Python";
      Assert.Equal("Python", room.Name);
    }

    /// <summary>
    /// get amenities property
    /// </summary>
    [Fact]
    public void GetAmenityName()
    {
      Amenity amenity = new Amenity();
      amenity.Name = "MyPerk";

      Assert.Equal("MyPerk", amenity.Name);

    }
    /// <summary>
    /// test is can change model property for amenities
    /// </summary>
    [Fact]
    public void SetAmenityName()
    {
      Amenity amenity = new Amenity();
      amenity.Name = "Potions";
      amenity.Name = "Python";
      Assert.Equal("Python", amenity.Name);
    }

    /// <summary>
    /// get hotel room property
    /// </summary>
    [Fact]
    public void GetHotelRoomName()
    {
      HotelRoom room = new HotelRoom();
      room.RoomID = 2;

      Assert.Equal(2, room.RoomID);

    }
    /// <summary>
    /// test is can change model property for hotel rooms
    /// </summary>
    [Fact]
    public void SetHotelRoomName()
    {
      HotelRoom room = new HotelRoom();
      room.RoomID = 2;
      room.RoomID = 3;
      Assert.Equal(3, room.RoomID);
    }

    /// <summary>
    /// get room amenity property
    /// </summary>
    [Fact]
    public void GetRoomAmenityName()
    {
      RoomAmenity room = new RoomAmenity();
      room.AmenityID = 2;

      Assert.Equal(2, room.AmenityID);

    }
    /// <summary>
    /// test is can change model property for hotel rooms
    /// </summary>
    [Fact]
    public void SetRoomAmenityName()
    {
      RoomAmenity room = new RoomAmenity();
      room.RoomID = 2;
      room.RoomID = 3;
      Assert.Equal(3, room.RoomID);
    }

    /// <summary>
    /// tests create an entry in the hotel table and then to read it
    /// </summary>
    [Fact]
    public async void CreateAndReadHotel()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("CreateHotel")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Hotel hotel = new Hotel();
        hotel.Address = "blah";
        hotel.Name = "as";
        hotel.Phone = "gs";

        context.Hotels.Add(hotel);
        context.SaveChanges();

        var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);

        // Assert
        Assert.Equal("as", hotelName.Name);


      }
    }

    /// <summary>
    /// tests update in the hotel table
    /// </summary>
    [Fact]
    public async void UpdateHotel()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("UpdateHotel")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Hotel hotel = new Hotel();
        hotel.Address = "blah";
        hotel.Name = "as";
        hotel.Phone = "gs";
        context.Hotels.Add(hotel);
        context.SaveChanges();
        hotel.Name = "updatedhotelname";
        context.Hotels.Update(hotel);
        context.SaveChanges();
        var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
        // Assert
        Assert.Equal("updatedhotelname", hotelName.Name);
      }
    }

    /// <summary>
    /// tests delete for hotel
    /// </summary>
    [Fact]
    public async void DeleteHotel()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("DeleteHotel")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Hotel hotel = new Hotel();
        hotel.Address = "blah";
        hotel.Name = "as";
        hotel.Phone = "gs";
        context.Hotels.Add(hotel);
        context.SaveChanges();
        context.Hotels.Remove(hotel);
        context.SaveChanges();
        var hotelName = await context.Hotels.FirstOrDefaultAsync(x => x.Name == hotel.Name);
        // Assert
        Assert.Null(hotelName);
      }
    }


    /// <summary>
    /// tests create an entry in the Rooms table and then to read it
    /// </summary>
    [Fact]
    public async void CreateAndReadRoom()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("CreateRoom")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Room room = new Room();
        room.Name = "blah";

        context.Rooms.Add(room);
        context.SaveChanges();

        var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);

        // Assert
        Assert.Equal("blah", roomName.Name);


      }
    }

    /// <summary>
    /// tests update in the rooms table
    /// </summary>
    [Fact]
    public async void UpdateRoom()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("UpdateRoom")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Room room = new Room();
        room.Name = "asetest";
        context.Rooms.Add(room);
        context.SaveChanges();
        room.Name = "updatedroomname";
        context.Rooms.Update(room);
        context.SaveChanges();
        var roomName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);
        // Assert
        Assert.Equal("updatedroomname", roomName.Name);
      }
    }

    /// <summary>
    /// tests delete for rooms table
    /// </summary>
    [Fact]
    public async void DeleteRoom()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("DeleteRoom")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Room room = new Room();
        room.Name = "as";
        context.Rooms.Add(room);
        context.SaveChanges();
        context.Rooms.Remove(room);
        context.SaveChanges();
        var hotelName = await context.Rooms.FirstOrDefaultAsync(x => x.Name == room.Name);
        // Assert
        Assert.Null(hotelName);
      }
    }


    /// <summary>
    /// tests create an entry in the amenities table and then to read it
    /// </summary>
    [Fact]
    public async void CreateAndReadAmenities()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("CreateAmenity")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Amenity amenity = new Amenity();
        amenity.Name = "as";

        context.Amenities.Add(amenity);
        context.SaveChanges();

        var amenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);

        // Assert
        Assert.Equal("as", amenityName.Name);


      }
    }

    /// <summary>
    /// tests update in the amenities table
    /// </summary>
    [Fact]
    public async void UpdateAmenity()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("UpdateAmenity")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Amenity amenity = new Amenity();
        amenity.Name = "as";
        context.Amenities.Add(amenity);
        context.SaveChanges();
        amenity.Name = "updatedamenityname";
        context.Amenities.Update(amenity);
        context.SaveChanges();
        var amenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);
        // Assert
        Assert.Equal("updatedamenityname", amenityName.Name);
      }
    }

    /// <summary>
    /// tests delete for amenities table
    /// </summary>
    [Fact]
    public async void DeleteAmenity()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("DeleteAmenity")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        Amenity amenity = new Amenity();
        amenity.Name = "as";
        context.Amenities.Add(amenity);
        context.SaveChanges();
        context.Amenities.Remove(amenity);
        context.SaveChanges();
        var AmenityName = await context.Amenities.FirstOrDefaultAsync(x => x.Name == amenity.Name);
        // Assert
        Assert.Null(AmenityName);
      }
    }

    /// <summary>
    /// tests create an entry in the Hotel Rooms table and then to read it
    /// </summary>
    [Fact]
    public async void CreateAndReadHotelRooms()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("CreateHotelRooms")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        HotelRoom hotelRoom = new HotelRoom();
        hotelRoom.Rate = 199;

        context.HotelRooms.Add(hotelRoom);
        context.SaveChanges();

        var amenityName = await context.HotelRooms.FirstOrDefaultAsync(x => x.Rate == hotelRoom.Rate);

        // Assert
        Assert.Equal(199, hotelRoom.Rate);


      }
    }

    /// <summary>
    /// tests update in the hotel rooms table
    /// </summary>
    [Fact]
    public async void UpdateHotelRooms()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("UpdatHotelRoom")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        HotelRoom hotelRoom = new HotelRoom();
        hotelRoom.Rate = 199;

        context.HotelRooms.Add(hotelRoom);
        context.SaveChanges();
        hotelRoom.Rate = 299;
        context.HotelRooms.Update(hotelRoom);
        context.SaveChanges();
        var amenityName = await context.HotelRooms.FirstOrDefaultAsync(x => x.Rate == hotelRoom.Rate);
        // Assert
        Assert.Equal(299, hotelRoom.Rate);
      }
    }

    /// <summary>
    /// tests delete for hotel rooms table
    /// </summary>
    [Fact]
    public async void DeleteHotelRoom()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("DeleteHotelRoom")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        HotelRoom hotelRoom = new HotelRoom();
        hotelRoom.Rate = 199;
  
        context.HotelRooms.Add(hotelRoom);
        context.SaveChanges();
        context.HotelRooms.Remove(hotelRoom);
        context.SaveChanges();
        var AmenityRate = await context.HotelRooms.FirstOrDefaultAsync(x => x.Rate == hotelRoom.Rate);
        // Assert
        Assert.Null(AmenityRate);
      }
    }

    /// <summary>
    /// tests create an entry in the Room Amenities table and then to read it
    /// the room amenities table cannot be edit. only created and be deleted.
    /// </summary>
    [Fact]
    public async void CreateAndReadRoomAmenities()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("CreateRoomAmenities")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        RoomAmenity test = new RoomAmenity();
        test.AmenityID = 199;
        test.RoomID = 299;

        context.RoomAmenities.Add(test);
        context.SaveChanges();

        var testName = await context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == test.RoomID);

        // Assert
        Assert.Equal(299, testName.RoomID);


      }
    }

    /// <summary>
    /// tests delete for room Amenities table
    /// </summary>
    [Fact]
    public async void DeleteRoomAmenities()
    {
      DbContextOptions<AsyncInnDbContext> options =
      new DbContextOptionsBuilder<AsyncInnDbContext>()
      .UseInMemoryDatabase("DeleteAmenity")
      .Options;

      using (AsyncInnDbContext context = new AsyncInnDbContext(options))
      {
        //Arrange
        RoomAmenity test = new RoomAmenity();
        test.AmenityID = 199;
        test.RoomID = 299;

        context.RoomAmenities.Add(test);
        context.SaveChanges();
        context.RoomAmenities.Remove(test);
        context.SaveChanges();
        var AmenityRate = await context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == test.RoomID);
        // Assert
        Assert.Null(AmenityRate);
      }
    }
  }
}
