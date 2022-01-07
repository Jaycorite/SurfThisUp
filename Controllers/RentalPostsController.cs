using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfThisUp.Areas.Identity.Data;
using SurfThisUp.Models.Rent;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SurfThisUp.Controllers
{
    public class RentalPostsController : Controller
    {
        private readonly SurfThisUpContext _context;

        public RentalPostsController(SurfThisUpContext context)
        {
            _context = context;
        }

        // GET: RentalPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalPosts.ToListAsync());
        }

        // GET: RentalPosts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPost = await _context.RentalPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPost == null)
            {
                return NotFound();
            }

            return View(rentalPost);
        }

        // GET: RentalPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titel,Description,Price")] RentalPost rentalPost)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            rentalPost.Owner = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (ModelState.IsValid)
            {
                _context.Add(rentalPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPost);
        }

        // GET: RentalPosts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPost = await _context.RentalPosts.FindAsync(id);
            if (rentalPost == null)
            {
                return NotFound();
            }
            return View(rentalPost);
        }

        // POST: RentalPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Titel,Description,Price")] RentalPost rentalPost)
        {
            if (id != rentalPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPostExists(rentalPost.Id))
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
            return View(rentalPost);
        }

        // GET: RentalPosts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPost = await _context.RentalPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPost == null)
            {
                return NotFound();
            }

            return View(rentalPost);
        }

        // POST: RentalPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rentalPost = await _context.RentalPosts.FindAsync(id);
            _context.RentalPosts.Remove(rentalPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalPostExists(string id)
        {
            return _context.RentalPosts.Any(e => e.Id == id);
        }
    }
}
