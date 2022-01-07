using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfThisUp.Areas.Identity.Data;
using SurfThisUp.Models.Social;

namespace SurfThisUp.Controllers
{
    public class SocialPostsController : Controller
    {
        private readonly SurfThisUpContext _context;

        public SocialPostsController(SurfThisUpContext context)
        {
            _context = context;
        }

        // GET: SocialPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialPosts.ToListAsync());
        }

        // GET: SocialPosts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialPost = await _context.SocialPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialPost == null)
            {
                return NotFound();
            }

            return View(socialPost);
        }

        // GET: SocialPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Created")] SocialPost socialPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialPost);
        }

        // GET: SocialPosts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialPost = await _context.SocialPosts.FindAsync(id);
            if (socialPost == null)
            {
                return NotFound();
            }
            return View(socialPost);
        }

        // POST: SocialPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Content,Created")] SocialPost socialPost)
        {
            if (id != socialPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialPostExists(socialPost.Id))
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
            return View(socialPost);
        }

        // GET: SocialPosts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialPost = await _context.SocialPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialPost == null)
            {
                return NotFound();
            }

            return View(socialPost);
        }

        // POST: SocialPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var socialPost = await _context.SocialPosts.FindAsync(id);
            _context.SocialPosts.Remove(socialPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialPostExists(string id)
        {
            return _context.SocialPosts.Any(e => e.Id == id);
        }
    }
}
