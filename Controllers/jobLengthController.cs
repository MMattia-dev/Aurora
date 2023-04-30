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
    public class jobLengthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public jobLengthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: jobLength
        public async Task<IActionResult> Index()
        {
              return _context.jobLength != null ? 
                          View(await _context.jobLength.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.jobLength'  is null.");
        }

        // GET: jobLength/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.jobLength == null)
            {
                return NotFound();
            }

            var jobLength = await _context.jobLength
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobLength == null)
            {
                return NotFound();
            }

            return View(jobLength);
        }

        // GET: jobLength/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: jobLength/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Length")] jobLength jobLength)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobLength);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobLength);
        }

        // GET: jobLength/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.jobLength == null)
            {
                return NotFound();
            }

            var jobLength = await _context.jobLength.FindAsync(id);
            if (jobLength == null)
            {
                return NotFound();
            }
            return View(jobLength);
        }

        // POST: jobLength/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Length")] jobLength jobLength)
        {
            if (id != jobLength.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobLength);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jobLengthExists(jobLength.Id))
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
            return View(jobLength);
        }

        // GET: jobLength/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.jobLength == null)
            {
                return NotFound();
            }

            var jobLength = await _context.jobLength
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobLength == null)
            {
                return NotFound();
            }

            return View(jobLength);
        }

        // POST: jobLength/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.jobLength == null)
            {
                return Problem("Entity set 'ApplicationDbContext.jobLength'  is null.");
            }
            var jobLength = await _context.jobLength.FindAsync(id);
            if (jobLength != null)
            {
                _context.jobLength.Remove(jobLength);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool jobLengthExists(int id)
        {
          return (_context.jobLength?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
