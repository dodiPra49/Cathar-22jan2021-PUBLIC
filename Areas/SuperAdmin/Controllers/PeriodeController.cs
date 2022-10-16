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
    public class PeriodeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeriodeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/Periode
        public IActionResult Index(int page = 1, string searchString = "",
          string sortOrder = "IdDesc", string ErrorMsg = "")
        {
            if (ErrorMsg != "" )
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            ViewData["BulanParm"] = String.IsNullOrEmpty(sortOrder) ? "BulanDesc" : "";
            ViewData["TahunParm"] = String.IsNullOrEmpty(sortOrder) ? "TahunDesc" : "";
            ViewData["IdParm"] = String.IsNullOrEmpty(sortOrder) ? "IdDesc" : "";

            var rowList = from c in _context.Periode.Where(a=> a.Aktif=="1").OrderByDescending(c=>c.Id)
                          select new Periode()
                          {
                              Id = c.Id,
                              Tahun = c.Tahun,
                              Bulan = c.Bulan
                          };

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                rowList = rowList.Where(c => c.Id.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "TahunDesc":
                    rowList = rowList.OrderByDescending(s => s.Tahun);
                    break;
                case "BulanDesc":
                    rowList = rowList.OrderByDescending(s => s.Bulan);
                    break;
                case "IdDesc":
                    rowList = rowList.OrderByDescending(s => s.Id);
                    break;
            }

            return View(rowList.GetPaged(page, 15));
        }

        // GET: SuperAdmin/Periode/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periode == null)
            {
                return NotFound();
            }

            return View(periode);
        }

        // GET: SuperAdmin/Periode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Periode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tahun,Bulan")] Periode periode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periode);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new { ErrorMsg = SD.msgSave });
            }
            return View(periode);
        }

        // GET: SuperAdmin/Periode/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode.FindAsync(id);
            if (periode == null)
            {
                return NotFound();
            }
            return View(periode);
        }

        // POST: SuperAdmin/Periode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Tahun,Bulan")] Periode periode)
        {
            if (id != periode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodeExists(periode.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgEdit });
            }
            return View(periode);
        }

        //public async Task<IActionResult> Simpan(string id)
        //{
        //    if (id != "")
        //    {
        //        return NotFound();
        //    }

        //    //string aa = bulanid.value;
        //        return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgEdit });
 
        //}



        // GET: SuperAdmin/Periode/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periode = await _context.Periode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periode == null)
            {
                return NotFound();
            }

            return View(periode);
        }

        // POST: SuperAdmin/Periode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var periode = await _context.Periode.FindAsync(id);
            _context.Periode.Remove(periode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgDel });
        }

        private bool PeriodeExists(string id)
        {
            return _context.Periode.Any(e => e.Id == id);
        }
    }
}
