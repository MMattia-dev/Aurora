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
    public class timeLengthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public timeLengthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: timeLength
        public async Task<IActionResult> Index()
        {
              return _context.timeLength != null ? 
                          View(await _context.timeLength.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.timeLength'  is null.");
        }

        // GET: timeLength/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.timeLength == null)
            {
                return NotFound();
            }

            var timeLength = await _context.timeLength
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLength == null)
            {
                return NotFound();
            }

            return View(timeLength);
        }

        // GET: timeLength/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: timeLength/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Length,Pricing")] timeLength timeLength)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeLength);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeLength);
        }

        // GET: timeLength/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.timeLength == null)
            {
                return NotFound();
            }

            var timeLength = await _context.timeLength.FindAsync(id);
            if (timeLength == null)
            {
                return NotFound();
            }
            return View(timeLength);
        }

        // POST: timeLength/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Length,Pricing")] timeLength timeLength)
        {
            if (id != timeLength.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeLength);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!timeLengthExists(timeLength.Id))
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
            return View(timeLength);
        }

        // GET: timeLength/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.timeLength == null)
            {
                return NotFound();
            }

            var timeLength = await _context.timeLength
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLength == null)
            {
                return NotFound();
            }

            return View(timeLength);
        }

        // POST: timeLength/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.timeLength == null)
            {
                return Problem("Entity set 'ApplicationDbContext.timeLength'  is null.");
            }
            var timeLength = await _context.timeLength.FindAsync(id);
            if (timeLength != null)
            {
                _context.timeLength.Remove(timeLength);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool timeLengthExists(int id)
        {
          return (_context.timeLength?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
