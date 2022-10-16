using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class JamKerjaPolaDtController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;

        public JamKerjaPolaDtController(ApplicationDbContext context, ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        // GET: SuperAdmin/JamKerjaPolaDt
        public async Task<IActionResult> Index(int idPolaPilih = 0, string ErrorMsg = "")
        {
            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }
            //if (idPolaPilih == 0)
            //{
            //    ViewData["IdPola"] = new SelectList(
            //     _context.JamKerjaPola.Where(u => u.ValidTill == null || u.ValidTill <= SD.CutOff)
            //     , "Id", "Uraian");
            //}
            //else
            //{


            var _cutoff = _varServiceUser.GetToday();

            ViewData["IdPola"] = new SelectList(
                    _context.JamKerjaPola.Where(u => u.ValidTill == null || u.ValidTill <= _cutoff)
                    , "Id", "Uraian", idPolaPilih);
            //}

            if (idPolaPilih == 0) idPolaPilih = 1;
            var applicationDbContext = _context.JamKerjaPolaDt
                .Where(u => u.IdPola == idPolaPilih)
                .Include(u => u.IdPolaNavigation)
                .Include(u => u.IdDowNavigation);
            //if (idPolaPilih == 0) idPolaPilih = 1;
            ViewBag.IdPolaPilih = idPolaPilih;
            //else ViewBag.IdPolaPilih = "";
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperAdmin/JamKerjaPolaDt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt
                .Include(j => j.IdPolaNavigation)
                .FirstOrDefaultAsync(m => m.IdPola == id);
            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }

            return View(jamKerjaPolaDt);
        }

        // GET: SuperAdmin/JamKerjaPolaDt/Create
        public IActionResult Create(int idPola)
        {
            var rList = _context.JamKerjaPola.Where(u => u.Id == idPola).FirstOrDefault();
            ViewBag.NamaPola = rList.Uraian;

            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian");
            //ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian");
            JamKerjaPolaDt jamKerjaPolaDt = new JamKerjaPolaDt
            {
                IdPola = idPola
            };
            return View(jamKerjaPolaDt);
        }

        // POST: SuperAdmin/JamKerjaPolaDt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPola,IdDow,MasukA,KeluarA,MasukB,KeluarB")] JamKerjaPolaDt jamKerjaPolaDt)
        {
            if (ModelState.IsValid)
            {
                if (!JamKerjaPolaDtExists(jamKerjaPolaDt.IdPola, jamKerjaPolaDt.IdDow))
                {
                    _context.Add(jamKerjaPolaDt);
                    await _context.SaveChangesAsync();
                    ViewBag.ErrorMsg = SD.msgSave;
                    return RedirectToAction("Create", new { idPola = jamKerjaPolaDt.IdPola });
                }
                ViewBag.ErrorMsg = SD.msgErrModel;
            }
            ViewBag.ErrorMsg = SD.msgErrModel;
            ViewData["IdDow"] = new SelectList(_context.ListHari, "Id", "Uraian");
            //ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian", jamKerjaPolaDt.IdPola);
            return View(jamKerjaPolaDt);
        }

        // GET: SuperAdmin/JamKerjaPolaDt/Edit/5
        public async Task<IActionResult> Edit(int idpola, int iddow)
        {
            if (idpola == 0)
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt
               .Where(u => u.IdPola == idpola)
               .Where(u => u.IdDow == iddow)
               .Include(u => u.IdDowNavigation)
               .Include(u => u.IdPolaNavigation)
               .FirstOrDefaultAsync();

            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian"
                , jamKerjaPolaDt.IdDow);
            return View(jamKerjaPolaDt);
        }


        // POST: SuperAdmin/JamKerjaPolaDt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdPola,IdDow,MasukA,KeluarA,MasukB,KeluarB")] JamKerjaPolaDt jamKerjaPolaDt)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (JamKerjaPolaDtExists(jamKerjaPolaDt.IdPola, jamKerjaPolaDt.IdDow))
                    {
                        _context.Update(jamKerjaPolaDt);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index),
                            new { idPolaPilih = jamKerjaPolaDt.IdPola, ErrorMsg = SD.msgSave });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JamKerjaPolaDtExists(jamKerjaPolaDt.IdPola, jamKerjaPolaDt.IdDow))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { idPolaPilih = jamKerjaPolaDt.IdPola });
            }
            ViewData["IdPola"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian", jamKerjaPolaDt.IdPola);
            return View(jamKerjaPolaDt);
        }
        // GET: SuperAdmin/JamKerjaPolaDt/Delete/5
        public async Task<IActionResult> Delete(int idpola, int iddow)
        {
            if (!JamKerjaPolaDtExists(idpola, iddow))
            {
                return NotFound();
            }

            var jamKerjaPolaDt = await _context.JamKerjaPolaDt
                .Include(j => j.IdPolaNavigation)
                .Include(j => j.IdDowNavigation)
                .FirstOrDefaultAsync(m => m.IdPola == idpola && m.IdDow == iddow);
            if (jamKerjaPolaDt == null)
            {
                return NotFound();
            }

            return View(jamKerjaPolaDt);
        }

        // POST: SuperAdmin/JamKerjaPolaDt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int idpola, int iddow)
        {
            if (JamKerjaPolaDtExists(idpola, iddow))
            {
                var jamKerjaPolaDt = await _context.JamKerjaPolaDt
                    .Include(j => j.IdPolaNavigation)
                    .Include(j => j.IdDowNavigation)
                    .FirstOrDefaultAsync(m => m.IdPola == idpola && m.IdDow == iddow);
                _context.JamKerjaPolaDt.Remove(jamKerjaPolaDt);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index),
                new { idPolaPilih = idpola, ErrorMsg = SD.msgDel });
        }

        private bool JamKerjaPolaDtExists(int idPola, int idDow)
        {
            return _context.JamKerjaPolaDt.Any(e => e.IdPola == idPola && e.IdDow == idDow);
        }
    }
}
