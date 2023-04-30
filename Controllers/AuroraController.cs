using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aurora.Data;
using Aurora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Aurora.Controllers
{
    //[Authorize]
    public class AuroraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuroraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private NMEntities db = new NMEntities();

        //private AuroraModel db = new AuroraModel();


        //public class Models
        //{
        //    public IEnumerable<AuroraModel> auroraModels { get; set; }
        //    public IEnumerable<jobLength> jobLengths { get; set; }

        //}

        // GET: Aurora
        public async Task<IActionResult> Index()
        {
            //Models models = new Models();
            //models.jobLengths = _context.jobLength;
            //return View(models);



            return _context.AuroraModel != null ?
                        View(await _context.AuroraModel.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.AuroraModel'  is null.");


            //tel. do ViewBag

            //var Type = new List<dynamic>();
            //Type.Add(new { Type = "Etykieta" });
            //Type.Add(new { Type = "List" });
            //Type.Add(new { Type = "Faktura" });
            //Type.Add(new { Type = "DUNN" });
            //ViewBag.Type = Type;
            //ViewBag.Batche = db.BatchList.OrderByDescending(x => x.BizmanRunId);
            //ViewBag.Stale = db.stale_program_nm;
            //return View();

            //var JobLength = new List<dynamic>();
            //JobLength.Add(new { JobLength = "Etykieta" });
            //JobLength.Add(new { JobLength = "List" });
            //ViewBag.JobLength = JobLength;
            //ViewBag.JobLengths = 
        }

        //public async Task<IActionResult>

        // GET: Aurora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuroraModel == null)
            {
                return NotFound();
            }

            var auroraModel = await _context.AuroraModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel == null)
            {
                return NotFound();
            }

            return View(auroraModel);
        }

        // GET: Aurora/Create
        public IActionResult Create()
        {
            ViewBag.jobLengths = _context.jobLength;
            ViewBag.timeLengths = _context.timeLength;
            return View();
        }

        // POST: Aurora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Title,Description,Date,AcceptStatus,Place,JobLength,JobWorkers,Phone,Name,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel auroraModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auroraModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auroraModel);
        }

        // GET: Aurora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuroraModel == null)
            {
                return NotFound();
            }

            var auroraModel = await _context.AuroraModel.FindAsync(id);
            if (auroraModel == null)
            {
                return NotFound();
            }
            return View(auroraModel);
        }

        // POST: Aurora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Title,Description,Date,AcceptStatus,Place,JobLength,JobWorkers,Phone,Name,TimeLength,JobEnd,JobHidden,JobDone")] AuroraModel auroraModel)
        {
            if (id != auroraModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auroraModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuroraModelExists(auroraModel.Id))
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
            return View(auroraModel);
        }

        // GET: Aurora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuroraModel == null)
            {
                return NotFound();
            }

            var auroraModel = await _context.AuroraModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auroraModel == null)
            {
                return NotFound();
            }

            return View(auroraModel);
        }

        // POST: Aurora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuroraModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AuroraModel'  is null.");
            }
            var auroraModel = await _context.AuroraModel.FindAsync(id);
            if (auroraModel != null)
            {
                _context.AuroraModel.Remove(auroraModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuroraModelExists(int id)
        {
          return (_context.AuroraModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
