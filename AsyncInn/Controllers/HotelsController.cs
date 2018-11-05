using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
  public class HotelsController : Controller
  {
    private readonly IHotels _hotels;
    public HotelsController(IHotels hotel)
    {
      _hotels = hotel;
    }

    // GET: Hotels
    //public async Task<IActionResult> Index()
    //{
    //  return View(await _hotels.GetHotels());
    //}

    public async Task<IActionResult> Index(string searchString)
    {
      var hotelsearch = from m in await _hotels.GetHotels()
                   select m;

      if (!String.IsNullOrEmpty(searchString))
      {
        hotelsearch = hotelsearch.Where(s => s.Name.Contains(searchString));
      }

      return View(hotelsearch.ToList());
    }

    // GET: Hotels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var hotel = await _hotels.GetHotel(id);
      if (hotel == null)
      {
        return NotFound();
      }

      return View(hotel);
    }

    // GET: Hotels/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Hotels/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
    {
      if (ModelState.IsValid)
      {
        await _hotels.CreateHotels(hotel);
        return RedirectToAction(nameof(Index));
      }
      return View(hotel);
    }

    // GET: Hotels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var hotel = await _hotels.GetHotel(id);
      if (hotel == null)
      {
        return NotFound();
      }
      return View(hotel);
    }

    // POST: Hotels/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
    {
      if (id != hotel.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _hotels.UpdateHotels(hotel);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!HotelExists(hotel.ID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(hotel);
    }

    // GET: Hotels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var hotel = await _hotels.GetHotel(id);
      if (hotel == null)
      {
        return NotFound();
      }

      return View(hotel);
    }

    // POST: Hotels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _hotels.DeleteHotels(id);
      return RedirectToAction(nameof(Index));
    }

    private bool HotelExists(int id)
    {
      return _hotels.GetHotel(id) != null;
    }
  }
}
