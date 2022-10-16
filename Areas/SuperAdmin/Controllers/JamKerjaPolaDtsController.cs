using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class JamKerjaPolaDtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JamKerjaPolaDtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/JamKerjaPolaDts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JamKerjaPolaDt.Include(j => j.IdDowNavigation).Include(j => j.IdPolaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperAdmin/JamKerjaPolaDts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt
                .Include(j => j.IdDowNavigation)
                .Include(j => j.IdPolaNavigation)
                .FirstOrDefaultAsync(m => m.IdPola == id);
            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }

            return View(jamKerjaPolaDt);
        }

        // GET: SuperAdmin/JamKerjaPolaDts/Create
        public IActionResult Create()
        {
            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian");
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian");
            return View();
        }

        // POST: SuperAdmin/JamKerjaPolaDts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPola,IdDow,MasukA,KeluarA,MasukB,KeluarB")] JamKerjaPolaDt jamKerjaPolaDt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jamKerjaPolaDt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian", jamKerjaPolaDt.IdDow);
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian", jamKerjaPolaDt.IdPola);
            return View(jamKerjaPolaDt);
        }

        // GET: SuperAdmin/JamKerjaPolaDts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt.FindAsync(id);
            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }
            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian", jamKerjaPolaDt.IdDow);
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian", jamKerjaPolaDt.IdPola);
            return View(jamKerjaPolaDt);
        }

        // POST: SuperAdmin/JamKerjaPolaDts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPola,IdDow,MasukA,KeluarA,MasukB,KeluarB")] JamKerjaPolaDt jamKerjaPolaDt)
        {
            if (id != jamKerjaPolaDt.IdPola)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jamKerjaPolaDt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JamKerjaPolaDtExists(jamKerjaPolaDt.IdPola))
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
            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian", jamKerjaPolaDt.IdDow);
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian", jamKerjaPolaDt.IdPola);
            return View(jamKerjaPolaDt);
        }

        // GET: SuperAdmin/JamKerjaPolaDts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt
                .Include(j => j.IdDowNavigation)
                .Include(j => j.IdPolaNavigation)
                .FirstOrDefaultAsync(m => m.IdPola == id);
            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }

            return View(jamKerjaPolaDt);
        }

        // POST: SuperAdmin/JamKerjaPolaDts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jamKerjaPolaDt = await _context.JamKerjaPolaDt.FindAsync(id);
            _context.JamKerjaPolaDt.Remove(jamKerjaPolaDt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JamKerjaPolaDtExists(int id)
        {
            return _context.JamKerjaPolaDt.Any(e => e.IdPola == id);
        }
    }
}
