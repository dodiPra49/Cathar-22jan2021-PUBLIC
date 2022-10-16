using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using New.Repositories;
using New.Utility;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Authorize(Roles = SD.SuperAdmin)]
    public class HariKerjaStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HariKerjaStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/HariKerjaStatus
        public IActionResult Index(int page = 1, string searchString = "",
          string sortOrder = "")
        {

            ViewData["IdParm"] = String.IsNullOrEmpty(sortOrder) ? "IdDesc" : "";
            ViewData["UraianParm"] = String.IsNullOrEmpty(sortOrder) ? "UraianDesc" : "";
 

            var rowList = from c in _context.HariKerjaStatus 
                          select new HariKerjaStatus()
                          {
                              Id = c.Id,
                              Uraian = c.Uraian,
                              Libur = c.Libur
                          };

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                rowList = rowList.Where(c => c.Uraian.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "IdDesc":
                    rowList = rowList.OrderByDescending(s => s.Id);
                    break;
                case "UraianDesc":
                    rowList = rowList.OrderByDescending(s => s.Uraian);
                    break;
 
            }

            return View(rowList.GetPaged(page, 15));
        }

        // GET: SuperAdmin/HariKerjaStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hariKerjaStatus = await _context.HariKerjaStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hariKerjaStatus == null)
            {
                return NotFound();
            }

            return View(hariKerjaStatus);
        }

        // GET: SuperAdmin/HariKerjaStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/HariKerjaStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Uraian,Libur")] HariKerjaStatus hariKerjaStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hariKerjaStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hariKerjaStatus);
        }

        // GET: SuperAdmin/HariKerjaStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hariKerjaStatus = await _context.HariKerjaStatus.FindAsync(id);
            if (hariKerjaStatus == null)
            {
                return NotFound();
            }
            return View(hariKerjaStatus);
        }

        // POST: SuperAdmin/HariKerjaStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uraian,Libur")] HariKerjaStatus hariKerjaStatus)
        {
            if (id != hariKerjaStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hariKerjaStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HariKerjaStatusExists(hariKerjaStatus.Id))
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
            return View(hariKerjaStatus);
        }

        // GET: SuperAdmin/HariKerjaStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hariKerjaStatus = await _context.HariKerjaStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hariKerjaStatus == null)
            {
                return NotFound();
            }

            return View(hariKerjaStatus);
        }

        // POST: SuperAdmin/HariKerjaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hariKerjaStatus = await _context.HariKerjaStatus.FindAsync(id);
            _context.HariKerjaStatus.Remove(hariKerjaStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HariKerjaStatusExists(int id)
        {
            return _context.HariKerjaStatus.Any(e => e.Id == id);
        }
    }
}
