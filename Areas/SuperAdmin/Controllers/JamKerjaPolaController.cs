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
    public class JamKerjaPolaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JamKerjaPolaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/JamKerjaPola
        public IActionResult Index(int page = 1, string searchString = "",
          string sortOrder = "")
        {

            ViewData["UraianParm"] = String.IsNullOrEmpty(sortOrder) ? "Uraiandesc" : "";
            ViewData["IdParm"] = String.IsNullOrEmpty(sortOrder) ? "Iddesc" : "";

            //var rowList = (from c in _context.JamKerjaPola
            //               select JamKerjaPola()
            //              );

            var rowList = _context.JamKerjaPola.AsQueryable(); //.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                rowList = rowList.Where(u => u.Uraian.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Uraiandesc":
                    rowList = rowList.OrderByDescending(s => s.ValidTill).
                        ThenBy(s => s.Uraian);

                    break;
                case "Iddesc":
                    rowList = rowList.OrderByDescending(s => s.ValidTill).
                       ThenBy(s => s.Id);
                    break;
            }

            return View(rowList.GetPaged(page, 15));
        }


        // GET: SuperAdmin/JamKerjaPola/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPola = await _context.JamKerjaPola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jamKerjaPola == null)
            {
                return NotFound();
            }

            return View(jamKerjaPola);
        }

        // GET: SuperAdmin/JamKerjaPola/Create
        public IActionResult Create()
        {
            var row = new JamKerjaPola
            {
                Id = NewId()
            };
            return View(row);
        }

        private int NewId()
        {
            int retVal = 0;
            var rList = _context.JamKerjaPola.OrderByDescending(u => u.Id).Take(1).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Id + 1;
            }
            return retVal;
        }

        // POST: SuperAdmin/JamKerjaPola/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uraian,ValidTill")]  JamKerjaPola jamKerjaPola)
        {

            if (ModelState.IsValid)
            {
                _context.Add(jamKerjaPola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jamKerjaPola);
        }

        // GET: SuperAdmin/JamKerjaPola/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPola = await _context.JamKerjaPola.FindAsync(id);
            if (jamKerjaPola == null)
            {
                return NotFound();
            }
            return View(jamKerjaPola);
        }

        // POST: SuperAdmin/JamKerjaPola/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uraian,ValidTill")] JamKerjaPola jamKerjaPola)
        {
            if (id != jamKerjaPola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jamKerjaPola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JamKerjaPolaExists(jamKerjaPola.Id))
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
            return View(jamKerjaPola);
        }

        // GET: SuperAdmin/JamKerjaPola/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPola = await _context.JamKerjaPola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jamKerjaPola == null)
            {
                return NotFound();
            }

            return View(jamKerjaPola);
        }

        // POST: SuperAdmin/JamKerjaPola/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jamKerjaPola = await _context.JamKerjaPola.FindAsync(id);
            _context.JamKerjaPola.Remove(jamKerjaPola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JamKerjaPolaExists(int id)
        {
            return _context.JamKerjaPola.Any(e => e.Id == id);
        }
    }
}
