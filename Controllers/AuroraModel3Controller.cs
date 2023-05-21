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
    public class AuroraModel3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuroraModel3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuroraModel3
        public async Task<IActionResult> Index()
        {
              return _context.AuroraModel3 != null ? 
                          View(await _context.AuroraModel3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AuroraModel3'  is null.");
        }

        // GET: AuroraModel3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuroraModel3 == null)
            {
                return NotFound();
            }

            var auroraModel3 = await _context.AuroraModel3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel3 == null)
            {
                return NotFound();
            }

            return View(auroraModel3);
        }

        // GET: AuroraModel3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuroraModel3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Title,Description,Date,Place,JobLength,Difficulty,JobWorkers,Phone,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel3 auroraModel3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auroraModel3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auroraModel3);
        }

        // GET: AuroraModel3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuroraModel3 == null)
            {
                return NotFound();
            }

            var auroraModel3 = await _context.AuroraModel3.FindAsync(id);
            if (auroraModel3 == null)
            {
                return NotFound();
            }
            return View(auroraModel3);
        }

        // POST: AuroraModel3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Title,Description,Date,Place,JobLength,Difficulty,JobWorkers,Phone,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel3 auroraModel3)
        {
            if (id != auroraModel3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auroraModel3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuroraModel3Exists(auroraModel3.Id))
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
            return View(auroraModel3);
        }

        // GET: AuroraModel3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuroraModel3 == null)
            {
                return NotFound();
            }

            var auroraModel3 = await _context.AuroraModel3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel3 == null)
            {
                return NotFound();
            }

            return View(auroraModel3);
        }

        // POST: AuroraModel3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuroraModel3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AuroraModel3'  is null.");
            }
            var auroraModel3 = await _context.AuroraModel3.FindAsync(id);
            if (auroraModel3 != null)
            {
                _context.AuroraModel3.Remove(auroraModel3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuroraModel3Exists(int id)
        {
          return (_context.AuroraModel3?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
