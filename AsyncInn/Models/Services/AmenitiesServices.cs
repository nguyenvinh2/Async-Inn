using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
  public class AmenitiesServices : IAmenities
  {
    private AsyncInnDbContext _context;
    public AmenitiesServices(AsyncInnDbContext context)
    {
      _context = context;
    }
    /// <summary>
    /// creates a new amneities in table
    /// </summary>
    /// <param name="Amenity"></param>
    /// <returns></returns>
    public async Task CreateAmenities(Amenity Amenity)
    {
      _context.Amenities.Add(Amenity);
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// delete ameniities based on id specified
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAmenities(int id)
    {
      Amenity Amenity = await GetAmenity(id);
      _context.Amenities.Remove(Amenity);
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// get list of all amenities
    /// </summary>
    /// <returns></returns>
    public async Task<List<Amenity>> GetAmenities()
    {
      return await _context.Amenities.ToListAsync();
    }
    /// <summary>
    /// get amenities by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Amenity> GetAmenity(int? id)
    {
      return await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
    }
    /// <summary>
    /// edit amenities properties
    /// </summary>
    /// <param name="Amenity"></param>
    /// <returns></returns>
    public async Task UpdateAmenities(Amenity Amenity)
    {
      _context.Amenities.Update(Amenity);
      await _context.SaveChangesAsync();
    }
  }
}
