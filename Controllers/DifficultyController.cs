using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aurora.Data;
using Aurora.Models;

namespace Aurora.Controllers
{
    public class DifficultyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DifficultyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Difficulty
        public async Task<IActionResult> Index()
        {
              return _context.Difficulty != null ? 
                          View(await _context.Difficulty.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Difficulty'  is null.");
        }

        // GET: Difficulty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Difficulty == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // GET: Difficulty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Difficulty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DifficultyLevel,DifficultyName")] Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(difficulty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(difficulty);
        }

        // GET: Difficulty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Difficulty == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulty.FindAsync(id);
            if (difficulty == null)
            {
                return NotFound();
            }
            return View(difficulty);
        }

        // POST: Difficulty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DifficultyLevel,DifficultyName")] Difficulty difficulty)
        {
            if (id != difficulty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(difficulty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DifficultyExists(difficulty.Id))
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
            return View(difficulty);
        }

        // GET: Difficulty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Difficulty == null)
            {
                return NotFound();
            }

            var difficulty = await _context.Difficulty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            return View(difficulty);
        }

        // POST: Difficulty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Difficulty == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Difficulty'  is null.");
            }
            var difficulty = await _context.Difficulty.FindAsync(id);
            if (difficulty != null)
            {
                _context.Difficulty.Remove(difficulty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DifficultyExists(int id)
        {
          return (_context.Difficulty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
