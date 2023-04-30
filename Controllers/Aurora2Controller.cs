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
    public class Aurora2Controller : Controller
    {
        public readonly ApplicationDbContext _context;

        public Aurora2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aurora2
        public async Task<IActionResult> Index()
        {
              return _context.AuroraModel2 != null ? 
                          View(await _context.AuroraModel2.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AuroraModel2'  is null.");
        }

        // GET: Aurora2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuroraModel2 == null)
            {
                return NotFound();
            }

            var auroraModel2 = await _context.AuroraModel2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel2 == null)
            {
                return NotFound();
            }

            return View(auroraModel2);
        }

        // GET: Aurora2/Create
        public IActionResult Create()
        {
            ViewBag.jobLengths = _context.jobLength;
            ViewBag.timeLengths = _context.timeLength;
            ViewBag.difficulty = _context.Difficulty;
            return View();
        }

        // POST: Aurora2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Title,Description,Date,Place,JobLength,Difficulty,JobWorkers,Phone,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel2 auroraModel2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auroraModel2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auroraModel2);
        }

        // GET: Aurora2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuroraModel2 == null)
            {
                return NotFound();
            }

            var auroraModel2 = await _context.AuroraModel2.FindAsync(id);
            if (auroraModel2 == null)
            {
                return NotFound();
            }
            return View(auroraModel2);
        }

        // POST: Aurora2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Title,Description,Date,Place,JobLength,Difficulty,JobWorkers,Phone,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel2 auroraModel2)
        {
            if (id != auroraModel2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auroraModel2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuroraModel2Exists(auroraModel2.Id))
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
            return View(auroraModel2);
        }

        // GET: Aurora2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuroraModel2 == null)
            {
                return NotFound();
            }

            var auroraModel2 = await _context.AuroraModel2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel2 == null)
            {
                return NotFound();
            }

            return View(auroraModel2);
        }

        // POST: Aurora2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuroraModel2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AuroraModel2'  is null.");
            }
            var auroraModel2 = await _context.AuroraModel2.FindAsync(id);
            if (auroraModel2 != null)
            {
                _context.AuroraModel2.Remove(auroraModel2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuroraModel2Exists(int id)
        {
          return (_context.AuroraModel2?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
