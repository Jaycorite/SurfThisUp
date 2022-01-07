using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfThisUp.Areas.Identity.Data;
using SurfThisUp.Models.Weather;

namespace SurfThisUp.Controllers
{
    public class WeatherConditionsController : Controller
    {
        private readonly SurfThisUpContext _context;

        public WeatherConditionsController(SurfThisUpContext context)
        {
            _context = context;
        }

        // GET: WeatherConditions
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherConditions.ToListAsync());
        }

        // GET: WeatherConditions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherCondition = await _context.WeatherConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherCondition == null)
            {
                return NotFound();
            }

            return View(weatherCondition);
        }

        // GET: WeatherConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temp,WeatherType")] WeatherCondition weatherCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherCondition);
        }

        // GET: WeatherConditions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherCondition = await _context.WeatherConditions.FindAsync(id);
            if (weatherCondition == null)
            {
                return NotFound();
            }
            return View(weatherCondition);
        }

        // POST: WeatherConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Temp,WeatherType")] WeatherCondition weatherCondition)
        {
            if (id != weatherCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherConditionExists(weatherCondition.Id))
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
            return View(weatherCondition);
        }

        // GET: WeatherConditions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherCondition = await _context.WeatherConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherCondition == null)
            {
                return NotFound();
            }

            return View(weatherCondition);
        }

        // POST: WeatherConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var weatherCondition = await _context.WeatherConditions.FindAsync(id);
            _context.WeatherConditions.Remove(weatherCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherConditionExists(string id)
        {
            return _context.WeatherConditions.Any(e => e.Id == id);
        }
    }
}
