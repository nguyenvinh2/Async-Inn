﻿using System;
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
  public class AmenitiesController : Controller
  {
    private readonly IAmenities _amenities;
    public AmenitiesController(IAmenities amenity)
    {
      _amenities = amenity;
    }


    // GET: Amenities
    public async Task<IActionResult> Index()
    {
      return View(await _amenities.GetAmenities());
    }

    // GET: Amenities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var amenity = await _amenities.GetAmenity(id);
      if (amenity == null)
      {
        return NotFound();
      }

      return View(amenity);
    }

    // GET: Amenities/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Amenities/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Name")] Amenity amenity)
    {
      if (ModelState.IsValid)
      {
        await _amenities.CreateAmenities(amenity);
        return RedirectToAction(nameof(Index));
      }
      return View(amenity);
    }

    // GET: Amenities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var amenity = await _amenities.GetAmenity(id);
      if (amenity == null)
      {
        return NotFound();
      }
      return View(amenity);
    }

    // POST: Amenities/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenity amenity)
    {
      if (id != amenity.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _amenities.UpdateAmenities(amenity);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!AmenityExists(amenity.ID))
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
      return View(amenity);
    }

    // GET: Amenities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var amenity = await _amenities.GetAmenity(id);
      if (amenity == null)
      {
        return NotFound();
      }

      return View(amenity);
    }

    // POST: Amenities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _amenities.DeleteAmenities(id);
      return RedirectToAction(nameof(Index));
    }

    private bool AmenityExists(int id)
    {
      return _amenities.GetAmenity(id) != null;
    }
  }
}
