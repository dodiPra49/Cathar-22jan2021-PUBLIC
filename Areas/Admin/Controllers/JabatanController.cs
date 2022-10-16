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
//using LoggerService;

namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JabatanController : Controller
    {
        private readonly IAllRepo<Jabatan> _repoJabatan;
        private readonly IAllRepo<UnitKerja> _repoUnitKerja;
       
        private readonly ServiceUser _varServiceUser;


        public JabatanController(IAllRepo<Jabatan> repoJabatan, IAllRepo<UnitKerja> repoUnitKerja,
            ServiceUser varServiceUser)
        {
            _repoJabatan = repoJabatan;
            _repoUnitKerja = repoUnitKerja;
            _varServiceUser = varServiceUser;
            

        }

        // RESET JABATAN 
        //        UPDATE A
        //SET A.VALIDTILL = '2018-12-31' 
        //FROM JABATAN A INNER JOIN
        //    UNITKERJA B ON A.IdUnitKerja = B.Id

        //    WHERE B.IdLevel = 99


        // GET: Admin/Jabatan
        public IActionResult Index(int IdUnitKerja = 0, int SubDiv = 1, int IdJabatan = 0, string ErrorMsg = "")
        {
            var _periode = _varServiceUser.GetPeriode();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            var _cutoff = _varServiceUser.GetToday();

            if (_periode == "" )
            {
                return RedirectToAction("Index", "SetPeriode", new { area = "SuperAdmin" });
            }

   

            ViewBag.ListUnitKerja = new SelectList(
                _repoUnitKerja.GetAll()
                .Where(u => u.ValidTill > _cutoff || u.ValidTill == null)
                .OrderBy( u => u.Uraian)
                , "Id", "Uraian", IdUnitKerja);

            ViewBag.IdUnitKerja = IdUnitKerja;
            ViewBag.SubDiv = SubDiv;
            ViewBag.IdJabatan = IdJabatan;
            ViewBag.ErrorMsg = ErrorMsg;

            var row = _repoJabatan.GetAll().ToList();
            if (IdUnitKerja != 0)
            {
                row = row.Where(u => u.IdUnitKerja == IdUnitKerja).ToList();
            }
            else
            {
                row = row.Where(u => u.IdUnitKerja == 0).ToList();
            }

            row = row.OrderBy(u => u.IdEselon).ThenBy(u => u.Urut).ToList();

            return View(row);

        }


        //public PartialViewResult GetAddress()
        //{
        //    return PartialView("_address");
        //}

        //// GET: Admin/Jabatan/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jabatan = await _context.Jabatan
        //        .Include(j => j.IdUnitKerjaNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jabatan == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(jabatan);
        //}

        // GET: Admin/Jabatan/Create
        //public IActionResult Create()
        //{
        //    ViewData["IdUnitKerja"] = new SelectList(_repoUnitKerja.GetAll(), "Id", "Uraian");
        //    return View();
        //}


        public PartialViewResult Create()
        {
            DateTime TglAwalPeriode;

            var tahun = HttpContext.Session.GetInt32(SD.ssTahun).GetValueOrDefault();
            var bulan = HttpContext.Session.GetInt32(SD.ssBulan).GetValueOrDefault();
            string strTgl = tahun.ToString() + "/" + bulan.ToString() + "/01";
            TglAwalPeriode = DateTime.Parse(strTgl.Replace("!", ":"));

            ViewBag.ListUnitKerja = new SelectList(_repoUnitKerja.GetAll()
                .Where(u => u.ValidTill > TglAwalPeriode || u.ValidTill == null)
                , "Id", "Uraian");

            Jabatan model = new Jabatan();
            return PartialView("_CreateA", model);
        }

        // POST: Admin/Jabatan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdUnitKerja,Uraian,IdEselon,Urut,IdJabatan,IdAtas,ValidTill")] Jabatan jabatan)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //repoJabatan.Insert(jabatan);
                    //repoJabatan.Save();
                    _repoJabatan.Insert(jabatan);
                    //_context.Add(jabatan);
                    //await 
                    //_context.SaveChangesAsync();
                    //}
                    ViewBag.ErrorMsg = "Your password has been changed.sss";
                    return RedirectToAction(nameof(Index), new
                    {
                        SubDiv = 2,
                        //IdUnitKerja = 
                        jabatan.IdUnitKerja,
                        ErrorMsg = "Jabatan " + jabatan.Uraian + " disimpan, lanjut"
                    });
                }
                catch (Exception ex)
                {
                    //    throw;
                    //}
                    //@ViewBag.errMessage = ex.Message;
                    //string theView = "~/Views/Errors/Index.cshtml";
                    //return RedirectToAction("Index", "Errors", new { area = "" });
                    //return View(theView);
                    //return PartialView("_CreateA", jabatan);
                    return RedirectToAction(nameof(Index), new
                    {
                        SubDiv = 2,
                        //IdUnitKerja = 
                        jabatan.IdUnitKerja,
                        ErrorMsg = ViewBag.ErrorMsg + ex.Message
                    }); ;
                }
                //return Redirect(returnUrl);
            }
            //ViewData["IdUnitKerja"] = new SelectList(_repoUnitKerja.Get(), "Id", "Uraian", jabatan.IdUnitKerja);

            ViewBag.ErrorMsg = "Gagal menyimpan data, ulangi";
            //return PartialView("_CreateA", jabatan);
            return RedirectToAction(nameof(Index), new
            {
                SubDiv = 2,
                //IdUnitKerja = 
                jabatan.IdUnitKerja,
                ViewBag.ErrorMsg
            });
        }

        //// GET: Admin/Jabatan/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jabatan =  _repoJabatan.GetById(id);
        //    //_context.Jabatan.FindAsync(id);
        //    if (jabatan == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdUnitKerja"] = new SelectList(_repoUnitKerja.Get(), "Id", "Uraian", jabatan.IdUnitKerja);
        //    return View(await  jabatan);
        //}

        //// POST: Admin/Jabatan/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IdUnitKerja,Uraian,IdEselon,Urut,IdJabatan,IdAtas,ValidTill")] Jabatan jabatan)
        {
            if (id != jabatan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _repoJabatan.Update(jabatan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_repoJabatan.GetById(jabatan.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new
                {
                    jabatan.IdUnitKerja,
                    SubDiv = 1,
                    IdJabatan = 0,
                    ErrorMsg = "Berhasil"
                });
            }
            //ViewData["IdUnitKerja"] = new SelectList(_repoUnitKerja.Get(), "Id", "Uraian", jabatan.IdUnitKerja);
            return View(jabatan);
        }

        //// GET: Admin/Jabatan/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var jabatan = _context.Jabatan 
        //        .Include(j => j.IdUnitKerjaNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (jabatan == null)
        //    {
        //        return NotFound();
        //    }

        //    return View( await jabatan);
        //}

        // POST: Admin/Jabatan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int IdUnitKerja)
        {
            _repoJabatan.Delete(id);


            //var jabatan = await _context.Jabatan.FindAsync(id);
            //_context.Jabatan.Remove(jabatan);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new
            {
                SubDiv = 1,
                IdUnitKerja,
                ErrorMsg = "Data dihapus"
            });

        }

        //private bool JabatanExists(int id)
        //{
        //    return _context.Jabatan.Any(e => e.Id == id);
        //}

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
    }
}
