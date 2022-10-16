using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using FastReport.Utils;
using FastReport.Data;
using FastReport.Web;
using New.ViewModel;
using Microsoft.AspNetCore.Authorization;
using New.Utility;
using New.Repositories;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Authorize(Roles = SD.SuperAdmin)]
    public class UnitKerjaController : Controller
    {


        private readonly ApplicationDbContext _context;

        public UnitKerjaController(
            ApplicationDbContext context
             )
        {
            _context = context;
            //_serviceDb = serviceDb;
        }

        [Authorize]
        // GET: SuperAdmin/UnitKerja
        public async Task<IActionResult> Index2()
        {
            return View(await _context.UnitKerja.ToListAsync());
        }

        [Authorize]
        public IActionResult Index(int page = 1, string searchString = "",
          string sortOrder = "", string ErrorMsg = "")
        {

            ViewData["UnitKerjaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Unitdesc" : "";
            ViewData["IdLevelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Iddesc" : "";

            var rowList = (from c in _context.UnitKerja select c);


            if (!string.IsNullOrWhiteSpace(searchString))
            {
                rowList = rowList.Where(c => c.Uraian.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Unitdesc":
                    rowList = rowList.OrderBy(u => u.ValidTill).ThenBy(s => s.Uraian);
                    break;
                case "Iddesc":
                    rowList = rowList.OrderBy(u => u.ValidTill).ThenBy(s => s.Id);
                    break;
            }

            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }
            //;
            return View(rowList.GetPaged(page, 15));
        }

        // GET: SuperAdmin/UnitKerja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitKerja = await _context.UnitKerja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitKerja == null)
            {
                return NotFound();
            }

            return View(unitKerja);
        }

        // GET: SuperAdmin/UnitKerja/Create
        public IActionResult Create(string ErrorMsg = "")
        {
            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }
            UnitKerja rowData = new UnitKerja
            {
                Id = NewId()
            };
            return View(rowData);
        }

        // POST: SuperAdmin/UnitKerja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uraian,IdLevel")] UnitKerja unitKerja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitKerja);
                await _context.SaveChangesAsync();
                //ViewBag.ErrorMsg = SD.msgSave;
                return RedirectToAction("Create", new { ErrorMsg = SD.msgSave });
            }
            else
            {
                ViewBag.ErrorMsg = SD.msgErrModel;
            }
            return View(unitKerja);
        }

        // GET: SuperAdmin/UnitKerja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitKerja = await _context.UnitKerja.FindAsync(id);
            if (unitKerja == null)
            {
                return NotFound();
            }
            return View(unitKerja);
        }

        // POST: SuperAdmin/UnitKerja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uraian,IdLevel,ValidTill")] UnitKerja unitKerja)
        {
            if (id != unitKerja.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitKerja);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitKerjaExists(unitKerja.Id))
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
            return View(unitKerja);
        }

        // GET: SuperAdmin/UnitKerja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitKerja = await _context.UnitKerja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitKerja == null)
            {
                return NotFound();
            }

            return View(unitKerja);
        }

        // POST: SuperAdmin/UnitKerja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitKerja = await _context.UnitKerja.FindAsync(id);
            _context.UnitKerja.Remove(unitKerja);
            await _context.SaveChangesAsync();
            //ViewBag.ErrorMsg = SD.msgDel;
            return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgDel });
        }

        private bool UnitKerjaExists(int id)
        {
            return _context.UnitKerja.Any(e => e.Id == id);
        }

        private int NewId()
        {
            int retVal = 1;
            var rowList = _context.UnitKerja.OrderByDescending(u => u.Id).Take(1).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.Id + 1;
            }
            return retVal;
        }
    }
}
