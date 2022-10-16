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

namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PeriodeKaSKPDController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;

        public PeriodeKaSKPDController(ApplicationDbContext context, ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        // GET: Admin/PeriodeKaSKPD
        public IActionResult Index(int page = 1, string ErrorMsg = "")
        {
            string _idperiode = _varServiceUser.GetPeriode();
            int _idunit = _varServiceUser.GetIdUnitKerja();

            if (_idperiode == "") return RedirectToAction("Index", "SetPeriode", new { area = "SuperAdmin" });

            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            var rowList = from c in _context.PeriodeKaSKPD
                          .Include(p => p.IdJabatanNavigation).Include(p => p.IdKaSKPDNavigation).OrderByDescending(C=>C.IdPeriode)
                          select c;

            //var periode = HttpContext.Session.GetString(SD.ssIdPeriode);
            //var idUnitKerja = HttpContext.Session.GetInt32(SD.ssIdUnit).GetValueOrDefault();

            rowList = rowList.Where(u => u.IdUnitKerja == _idunit);

            ViewBag.NamaUnitKerja = GetNamaUnit(_idunit);

            return View(rowList.GetPaged(page, 15));


            //var applicationDbContext = _context.PeriodeKaSKPD.Include(p => p.IdJabatanNavigation).Include(p => p.IdKaSKPDNavigation);
            //return View(await applicationDbContext.ToListAsync());
        }

        //// GET: Admin/PeriodeKaSKPD/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var periodeKaSKPD = await _context.PeriodeKaSKPD
        //        .Include(p => p.IdJabatanNavigation)
        //        .Include(p => p.IdKaSKPDNavigation)
        //        .FirstOrDefaultAsync(m => m.IdPeriode == id);
        //    if (periodeKaSKPD == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(periodeKaSKPD);
        //}

        // GET: Admin/PeriodeKaSKPD/Create
        public IActionResult Create()
        {

            //            var idPeriode = HttpContext.Session.GetString(SD.ssIdPeriode);
            //var idUnit = HttpContext.Session.GetInt32(SD.ssIdUnit).GetValueOrDefault();
            //var tahun = HttpContext.Session.GetInt32(SD.ssTahun).GetValueOrDefault();
            //var bulan = HttpContext.Session.GetInt32(SD.ssBulan).GetValueOrDefault();

            //string strTgl = HttpContext.Session.GetString(SD.ssCutOff);
            //DateTime tgl = DateTime.Parse(strTgl.Replace("!", ":"));
            var _periode = _varServiceUser.GetPeriode();
            var _cutoff = _varServiceUser.GetToday();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            int top1 = _context.Jabatan.Where(u => u.IdUnitKerja == _idunit).Min(u => u.IdEselon);

            ViewData["IdJabatan"] = new SelectList(
                    _context.Jabatan
                    .Where(u => u.ValidTill == null || u.ValidTill >= _cutoff)
                    .Where(u => u.IdEselon == top1 || u.IdEselon <= 31 && u.IdEselon != 0)
                    .Where(u => u.IdUnitKerja == _idunit)
                    .OrderByDescending(u => u.IdEselon)
                    , "Id", "Uraian");




            var rowList = new PeriodeKaSKPD
            {
                IdPeriode = _periode,
                IdUnitKerja = _idunit
            };

            return View(rowList);
        }

        // POST: Admin/PeriodeKaSKPD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriode,IdUnitKerja,IdJabatan,IdKaSKPD")] PeriodeKaSKPD periodeKaSKPD)
        {
            //var idPeriode = HttpContext.Session.GetString(SD.ssIdPeriode);
            //var idUnit = HttpContext.Session.GetInt32(SD.ssIdUnit).GetValueOrDefault();
            //var tahun = HttpContext.Session.GetInt32(SD.ssTahun).GetValueOrDefault();
            //var bulan = HttpContext.Session.GetInt32(SD.ssBulan).GetValueOrDefault();

            //string strTgl = tahun.ToString() + "/" + bulan.ToString() + "/01";
            //DateTime tgl = DateTime.Parse(strTgl.Replace("!", ":"));

            var _periode = _varServiceUser.GetPeriode();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            var _cutoff  = _varServiceUser.GetToday();

            if (ModelState.IsValid)
            {
                if (!PeriodeKaSKPDExists(_periode, _idunit))
                {
                    _context.Add(periodeKaSKPD);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgSave });
                }
            }


            ViewBag.ErrorMsg = SD.msgErrSave;



            ViewData["IdJabatan"] = new SelectList(
                    _context.Jabatan
                    .Where(u => u.ValidTill == null || u.ValidTill >= _cutoff)
                    .Where(u => u.IdEselon <= 31 && u.IdEselon != 0)
                    .Where(u => u.IdUnitKerja == _idunit)
                    .OrderByDescending(u => u.IdEselon)
                    , "Id", "Uraian");

            return View(periodeKaSKPD);
        }

        // GET: Admin/PeriodeKaSKPD/Edit/5
        public async Task<IActionResult> Edit(string idPeriode, int? idUnit)
        {
            if (idPeriode == null || idUnit.GetValueOrDefault() == 0)
            {
                return NotFound();
            }

            var periodeKaSKPD = await _context.PeriodeKaSKPD
                .Where(u => u.IdPeriode == idPeriode)
                .Where(u => u.IdUnitKerja == idUnit).FirstOrDefaultAsync();
            if (periodeKaSKPD == null)
            {
                return NotFound();
            }

            var _cutoff = _varServiceUser.GetToday();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            int top1 = _context.Jabatan.Where(u => u.IdUnitKerja == _idunit).Min(u => u.IdEselon);

            ViewData["IdJabatan"] = new SelectList(
                   _context.Jabatan
                   .Where(u => u.ValidTill == null || u.ValidTill >= _cutoff)
                   .Where(u => u.IdEselon == top1 || u.IdEselon <= 31 && u.IdEselon != 0)
                   .Where(u => u.IdUnitKerja == idUnit)
                   .OrderByDescending(u => u.IdEselon)
                   , "Id", "Uraian");

            var row = await _context.Pegawai
                    .Where(u => u.NIP == periodeKaSKPD.IdKaSKPD)
                    .FirstOrDefaultAsync();
            ViewBag.NamaPeg = "";
            if (row != null)
            {
                ViewBag.NamaPeg = row.Nama;
            }

            return View(periodeKaSKPD);
        }

        // POST: Admin/PeriodeKaSKPD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string idPeriode, [Bind("IdPeriode,IdUnitKerja,IdJabatan,IdKaSKPD")] PeriodeKaSKPD periodeKaSKPD)
        {

            if (idPeriode != periodeKaSKPD.IdPeriode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodeKaSKPD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodeKaSKPDExists(periodeKaSKPD.IdPeriode, periodeKaSKPD.IdUnitKerja))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgSave });
            }

            var _periode = _varServiceUser.GetPeriode();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            var _cutoff = _varServiceUser.GetToday();

            ViewData["IdJabatan"] = new SelectList(
                _context.Jabatan
                .Where(u => u.ValidTill == null || u.ValidTill >= _cutoff)
                .Where(u => u.IdEselon <= 31 && u.IdEselon != 0)
                .Where(u => u.IdUnitKerja == _idunit)
                .OrderByDescending(u => u.IdEselon)
                , "Id", "Uraian");
            ViewBag.ErrorMsg = SD.msgErrModel;
            return View(periodeKaSKPD);
        }

        // GET: Admin/PeriodeKaSKPD/Delete/5
        public async Task<IActionResult> Delete(string idPeriode, int? idUnit)
        {
            if (idPeriode == null || idUnit.GetValueOrDefault() == 0)
            {
                return NotFound();
            }
            var periodeKaSKPD = await _context.PeriodeKaSKPD
                .Where(u => u.IdPeriode == idPeriode)
                .Where(u => u.IdUnitKerja == idUnit)
                .Include(p => p.IdJabatanNavigation)
                .Include(p => p.IdKaSKPDNavigation)
                .FirstOrDefaultAsync();

            if (periodeKaSKPD == null)
            {
                return NotFound();
            }

            return View(periodeKaSKPD);
        }

        // POST: Admin/PeriodeKaSKPD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string idPeriode, int? idUnit)
        {
            var periodeKaSKPD = await _context.PeriodeKaSKPD
               .Where(u => u.IdPeriode == idPeriode)
               .Where(u => u.IdUnitKerja == idUnit).FirstOrDefaultAsync();

            _context.PeriodeKaSKPD.Remove(periodeKaSKPD);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgDel });
        }

        private bool PeriodeKaSKPDExists(string idPeriode, int idUnit)
        {
            bool retVal = true;
            var rList = _context.PeriodeKaSKPD
                .Where(e => e.IdPeriode == idPeriode)
                .Where(e => e.IdUnitKerja == idUnit).FirstOrDefault();
            if (rList == null) retVal = false;
            return retVal;
        }

        //private bool CekSessionPeriode()
        //{
        //    bool retVal = true;
        //    string ss = HttpContext.Session.GetString(SD.ssIdPeriode);
        //    if (ss == null || ss == "")
        //    {
        //        retVal = false;
        //    }

        //    return retVal;
        //}

        private string GetNamaUnit(int id)
        {
            string retVal = "";
            var rList = _context.UnitKerja.Where(u => u.Id == id).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Uraian;

            }

            return retVal;
        }

        [ActionName("GetNamaByNip")]
        public IActionResult GetNamaByNip(string id)
        {
            var retVal = "";
            var rowList = _context.Pegawai.Where(u => u.NIP == id).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.Nama;
            }

            return Json(retVal);
        }
    }
}
