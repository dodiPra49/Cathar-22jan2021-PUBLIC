using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class HariKerjaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;

        public HariKerjaController(
            ApplicationDbContext context,
            ServiceUser varServiceUser
            )
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        // GET: SuperAdmin/HariKerja
        public IActionResult Index(int page = 1,
            //string searchString = "",
            string sortOrder = "", string ErrorMsg = "")
        {


            if (!_varServiceUser.CekPeriodeTanggal())
            {
                ViewBag.ErrorMsg = "Set Periode dan Tanggal";
                return RedirectToAction("Index", "SetTanggal", new { area = "SuperAdmin" });
            }

            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            ViewData["TglParm"] = String.IsNullOrEmpty(sortOrder) ? "TglDesc" : "";
            ViewData["IdParm"] = String.IsNullOrEmpty(sortOrder) ? "IdDesc" : "";

            var rowList = from c in _context.HariKerja
                          .Include(h => h.IdLiburNavigation)

                          select new HariKerja()
                          {
                              Tanggal = c.Tanggal,
                              IdLibur = c.IdLibur,
                              IdLiburNavigation = c.IdLiburNavigation
                          };

            IsiAllTanggal(_varServiceUser.GetTahun(), _varServiceUser.GetBulan());
            rowList = rowList.Where(u => u.Tanggal.Month == _varServiceUser.GetBulan() 
                && u.Tanggal.Year == _varServiceUser.GetTahun());


            switch (sortOrder)
            {
                case "TglDesc":
                    rowList = rowList.OrderBy(s => s.Tanggal);
                    break;

                case "IdDesc":
                    rowList = rowList.OrderBy(s => s.IdLibur);
                    break;
            }

            return View(rowList.GetPaged(page, 15));
        }
         
        public IActionResult Create(string ErrorMsg = "")
        {
            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }
            ViewData["IdLibur"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian");
            return View();
        }

        // POST: SuperAdmin/HariKerja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tanggal,IdLibur")] HariKerja hariKerja)
        {
            if (ModelState.IsValid)
            {
                string myDate = hariKerja.Tanggal.ToString();
                if (HariKerjaExists(myDate))
                {
                    ViewBag.ErrorMsg = SD.msgErrSave;
                }
                else
                {
                    _context.Add(hariKerja);
                    await _context.SaveChangesAsync();
                    ViewBag.ErrorMsg = SD.msgSave;
                    return RedirectToAction("Create", new { ErrorMsg = SD.msgSave });
                }
                ViewData["IdLibur"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerja.IdLibur);
                return View(hariKerja);
            }
            else
            {
                ViewBag.ErrorMsg = SD.msgErrModel;
            }

            ViewData["IdLibur"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerja.IdLibur);
            return View(hariKerja);
        }

        // GET: SuperAdmin/HariKerja/Edit/5
        public async Task<IActionResult> Edit(int tgl, int bulan, int tahun )
        {
            DateTime myDate = new DateTime(tahun, bulan, tgl);
            
            //if (string.IsNullOrEmpty(id))
            //{
            //    return NotFound();
            //}
            //myDate = DateTime.Parse(id); //id.Replace("!", ":"));
            var hariKerja = await _context.HariKerja.FindAsync(myDate);
            if (hariKerja == null)
            {
                return NotFound();
            }
            ViewData["IdLibur"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerja.IdLibur);
            return View(hariKerja);
        }

        // POST: SuperAdmin/HariKerja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tanggal,IdLibur")] HariKerja hariKerja)
        {
            //DateTime myDate;
            //if (string.IsNullOrEmpty(id))
            //{
            //    return NotFound();
            //}
            ////myDate = DateTime.Parse(id.Replace("!", ":"));
            //var hariKerja = await _context.HariKerja.FindAsync(myDate);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hariKerja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HariKerjaExists(hariKerja.Tanggal.ToString()))
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
            ViewData["IdLibur"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerja.IdLibur);
            return View(hariKerja);
        }

        // GET: SuperAdmin/HariKerja/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            DateTime myDate;
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            myDate = DateTime.Parse(id.Replace("!", ":"));
            var hariKerja = await _context.HariKerja
                .Include(h => h.IdLiburNavigation)
                .FirstOrDefaultAsync(m => m.Tanggal == myDate);
            if (hariKerja == null)
            {
                return NotFound();
            }

            return View(hariKerja);
        }

        // POST: SuperAdmin/HariKerja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            DateTime myDate;
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            myDate = DateTime.Parse(id.Replace("!", ":"));
            var hariKerja = await _context.HariKerja.FindAsync(myDate);
            _context.HariKerja.Remove(hariKerja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgDel });
        }

        private bool HariKerjaExists(string id)
        {
            DateTime myDate = DateTime.Parse(id.Replace("!", ":"));
            return _context.HariKerja.Any(e => e.Tanggal == myDate);
        }

        private bool CekSessionPeriode()
        {
            bool retVal = true;
            string ss = HttpContext.Session.GetString(SD.ssIdPeriode);
            if (ss == null || ss == "")
            {
                retVal = false;
            }

            return retVal;
        }

        public void IsiAllTanggal(int tahun, int bulan)
        {
            string strTgl = tahun.ToString() + "/" + bulan.ToString() + "/01";
            DateTime tgl = DateTime.Parse(strTgl.Replace("!", ":"));
            while (tgl.Month == bulan && tgl.Year == tahun)
            {
                //jika tidak ada
                if (!HariKerjaExists(tgl.ToString()))
                {
                    HariKerja harikerja = new HariKerja();
                    harikerja.Tanggal = tgl;
                    harikerja.IdLibur = 1;
                    _context.Add(harikerja);
                    _context.SaveChanges();
                }
                tgl = tgl.AddDays(1);
            }

        }
    }
}
