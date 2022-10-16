using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;

namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RapatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RapatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Rapat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rapat.ToListAsync());
        }

        // GET: Admin/Rapat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapat = await _context.Rapat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapat == null)
            {
                return NotFound();
            }

            return View(rapat);
        }

        // GET: Admin/Rapat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Rapat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPeriode,Tanggal,WaktuMulai,WaktuHingga,Aktifitas,Tempat,Hasil,IdUnitKerja,Level")] Rapat rapat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapat);
        }

        // GET: Admin/Rapat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapat = await _context.Rapat.FindAsync(id);
            if (rapat == null)
            {
                return NotFound();
            }
            return View(rapat);
        }

        // POST: Admin/Rapat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPeriode,Tanggal,WaktuMulai,WaktuHingga,Aktifitas,Tempat,Hasil,IdUnitKerja,Level")] Rapat rapat)
        {
            if (id != rapat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapatExists(rapat.Id))
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
            return View(rapat);
        }

        // GET: Admin/Rapat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapat = await _context.Rapat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rapat == null)
            {
                return NotFound();
            }

            return View(rapat);
        }

        // POST: Admin/Rapat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapat = await _context.Rapat.FindAsync(id);
            _context.Rapat.Remove(rapat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapatExists(int id)
        {
            return _context.Rapat.Any(e => e.Id == id);
        }
    }
}
