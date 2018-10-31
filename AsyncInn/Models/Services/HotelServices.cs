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
    public async Task CreateHotels(Hotel Hotel)
    {
      _context.Hotels.Add(Hotel);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteHotels(int id)
    {
      Hotel Hotel = await GetHotel(id);
      _context.Hotels.Remove(Hotel);
      await _context.SaveChangesAsync();
    }

    public async Task<Hotel> GetHotel(int? id)
    {
      return await _context.Hotels.FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<List<Hotel>> GetHotels()
    {
      return await _context.Hotels.ToListAsync();
    }

    public async Task UpdateHotels(Hotel Hotel)
    {
      _context.Hotels.Update(Hotel);
      await _context.SaveChangesAsync();
    }
  }
}
