using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AsyncInn.Models.Services
{
  public class HotelServices : IHotels
  {
    private AsyncInnDbContext _context;
    public HotelServices(AsyncInnDbContext context)
    {
      _context = context;
    }
    /// <summary>
    /// creates a new hotel
    /// </summary>
    /// <param name="Hotel"></param>
    /// <returns></returns>
    public async Task CreateHotels(Hotel Hotel)
    {
      _context.Hotels.Add(Hotel);
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// deletes hotel based on id specified
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteHotels(int id)
    {
      Hotel Hotel = await GetHotel(id);
      _context.Hotels.Remove(Hotel);
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// retrieve hotel data based on id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Hotel> GetHotel(int? id)
    {
      return await _context.Hotels.FirstOrDefaultAsync(x => x.ID == id);
    }
    /// <summary>
    /// get list of all hotels in database
    /// </summary>
    /// <returns></returns>
    public async Task<List<Hotel>> GetHotels()
    {
      return await _context.Hotels.ToListAsync();
    }
    /// <summary>
    /// edit hotel properties in database
    /// </summary>
    /// <param name="Hotel"></param>
    /// <returns></returns>
    public async Task UpdateHotels(Hotel Hotel)
    {
      _context.Hotels.Update(Hotel);
      await _context.SaveChangesAsync();
    }
  }
}
