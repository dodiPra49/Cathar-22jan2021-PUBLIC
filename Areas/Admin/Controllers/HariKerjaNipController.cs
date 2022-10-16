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
using New.ViewModel;

namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HariKerjaNipController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;
       
        //private string _periode = "";
        //private int _idunit = 0;
        //private DateTime idunit;


        public HariKerjaNipController(ApplicationDbContext context, ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        private bool AdaTanggalPadaHKNip(string idperiode, string idnip, DateTime tgl)
        {
            var retVal = false;

            var row = _context.HariKerjaNip
                .Where(u => u.IdPeriode == idperiode)
                .Where(u => u.NIP == idnip)
                .Where(u => u.Tanggal == tgl);
            if (row.Count() != 0) retVal = true;

            return retVal;

        }

        private bool IsPolaHK(int idpola, int dow)
        {
            bool retVal = true;

            var row = _context.JamKerjaPolaDt
                .Where(u => u.IdPola == idpola)
                .Where(u => u.IdDow == dow);

            if (row.Count() == 0) retVal = false;
            return retVal;
                               }

        private void IsiAllTanggal(string idperiode, string idnip, int idpola)
        {
            var tahun = _varServiceUser.GetTahun();
            var bulan = _varServiceUser.GetBulan();
            var rList = _context.HariKerja
                .Where(u => u.Tanggal.Month == bulan)
                .Where(u => u.Tanggal.Year == tahun);

            foreach (var row in rList.ToList())
            {
                if (!AdaTanggalPadaHKNip(idperiode, idnip, row.Tanggal))
                {
                    var entryRow = new HariKerjaNip()
                    {
                        IdPeriode = idperiode,
                        NIP = idnip,
                        Tanggal = row.Tanggal,
                        IdHariKerjaStatus = row.IdLibur
                    };
                    var dt = (int)row.Tanggal.DayOfWeek;
                    if (!IsPolaHK(idpola, dt))
                    {
                        entryRow.IdHariKerjaStatus = 0;
                    };
                    _context.Add(entryRow);
                    _context.SaveChanges();
                }
            }
        }


        // GET: Admin/HariKerjaNip
        public IActionResult Index(string idnip = "", string strtgl = "", int idpola = 0)
        {


            HariKerjaNip rList = new HariKerjaNip();

            DateTime tgl = DateTime.Now.Date;
            var _periode = _varServiceUser.GetPeriode();
            var _idunit = _varServiceUser.GetIdUnitKerja();
            if (strtgl != "")
            {
                tgl = DateTime.Parse(strtgl);
            }


            ViewBag.tgl = tgl;
            if (idnip != "")
            {
                ViewBag.IdNip = idnip;
                IsiAllTanggal(_periode, idnip, idpola);
            }

            ViewBag.IdPeriode = _periode;
            ViewBag.IdUnit = _idunit;

            if (idnip != "")
            {
                rList = new HariKerjaNip()
                {
                    IdPeriode = _periode,
                    NIP = idnip,
                    Tanggal = tgl
                };
            }

            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", 0);
            return View(rList);
        }


        public IActionResult GetPegawaiList(string idperiode, int idunit)
        {

            var rowList = (from pn in _context.PeriodeNIP
                           join p in _context.Pegawai on pn.Nip equals p.NIP
                           where (pn.IdPeriode == idperiode) && (pn.IdUnitKerja == idunit)
                           select new PegawaiPeriodeUnitList
                           {
                               IdPeriode = pn.IdPeriode,
                               IdUnit = pn.IdUnitKerja,
                               Nip = pn.Nip,
                               Nama = p.Nama,
                               IdPola = pn.IdJamKerjaPola
                           });

            //return PartialView("_ListPeriodeNip", rowList);

            return PartialView("_ListPeriodeNip", rowList);
        }


        public IActionResult GetPegawaiTglList(string idperiode, string nip)
        {

            var rowList = _context.HariKerjaNip
                .Include(u => u.IdHariKerjaStatusNavigation)
                .Where(u => u.IdPeriode == idperiode)
                .Where(u => u.NIP == nip);


            //(from pn in _context.PeriodeNIP
            //           join p in _context.Pegawai on pn.Nip equals p.NIP
            //           where (pn.IdPeriode == idperiode) && (pn.IdUnitKerja == idunit)
            //           select new PegawaiPeriodeUnitList
            //           {
            //               IdPeriode = pn.IdPeriode,
            //               IdUnit = pn.IdUnitKerja,
            //               Nip = pn.Nip,
            //               Nama = p.Nama
            //           });

            //return PartialView("_ListPeriodeNip", rowList);

            return PartialView("_ListPeriodeTglNip", rowList);
        }



        [ActionName("GetNamaPeg")]
        public IActionResult GetNamaPeg(string id)
        {
            var retVal = "";
            var rowList = _context.Pegawai.Where(u => u.NIP == id).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.Nama;
            }

            return Json(retVal);
        }

        // GET: Admin/HariKerjaNip/Create
        public IActionResult Create()
        {

            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian");
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode");
            return View();
        }

        // POST: Admin/HariKerjaNip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriode,NIP,Tanggal,IdHariKerjaStatus")] HariKerjaNip hariKerjaNip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hariKerjaNip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerjaNip.IdHariKerjaStatus);
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", hariKerjaNip.IdPeriode);
            return View(hariKerjaNip);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CRUD(string tombol, [Bind("IdPeriode,NIP,Tanggal,IdHariKerjaStatus")]
            HariKerjaNip hariKerjaNip)
        {

            if (!ModelState.IsValid)
            {

                ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerjaNip.IdHariKerjaStatus);
                ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", hariKerjaNip.IdPeriode);
                return View(hariKerjaNip);
            }

            if (tombol == "Delete")
            {
                //try
                //{
                     _context.HariKerjaNip.Remove(hariKerjaNip);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index), new { idperiode = hariKerjaNip.IdPeriode, idnip = hariKerjaNip.NIP });
                //}

            }

            if (tombol == "Simpan")
            {
                if (AdaTanggalPadaHKNip(hariKerjaNip.IdPeriode, hariKerjaNip.NIP, hariKerjaNip.Tanggal))
                {
                    _context.Update(hariKerjaNip);
                    _context.SaveChanges();

                }
                else
                {
                    _context.Add(hariKerjaNip);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index), new { idperiode = hariKerjaNip.IdPeriode, idnip = hariKerjaNip.NIP });
            }

            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerjaNip.IdHariKerjaStatus);
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", hariKerjaNip.IdPeriode);
            return View(hariKerjaNip);
        }

        // GET: Admin/HariKerjaNip/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hariKerjaNip = await _context.HariKerjaNip.FindAsync(id);
            if (hariKerjaNip == null)
            {
                return NotFound();
            }
            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerjaNip.IdHariKerjaStatus);
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", hariKerjaNip.IdPeriode);
            return View(hariKerjaNip);
        }

        // POST: Admin/HariKerjaNip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPeriode,NIP,Tanggal,IdHariKerjaStatus")] HariKerjaNip hariKerjaNip)
        {
            if (id != hariKerjaNip.IdPeriode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hariKerjaNip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HariKerjaNipExists(hariKerjaNip.IdPeriode))
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
            ViewData["IdHariKerjaStatus"] = new SelectList(_context.HariKerjaStatus, "Id", "Uraian", hariKerjaNip.IdHariKerjaStatus);
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", hariKerjaNip.IdPeriode);
            return View(hariKerjaNip);
        }

        // GET: Admin/HariKerjaNip/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hariKerjaNip = await _context.HariKerjaNip
                .Include(h => h.IdHariKerjaStatusNavigation)
                .Include(h => h.PeriodeNIP)
                .FirstOrDefaultAsync(m => m.IdPeriode == id);
            if (hariKerjaNip == null)
            {
                return NotFound();
            }

            return View(hariKerjaNip);
        }

        // POST: Admin/HariKerjaNip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hariKerjaNip = await _context.HariKerjaNip.FindAsync(id);
            _context.HariKerjaNip.Remove(hariKerjaNip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HariKerjaNipExists(string id)
        {
            return _context.HariKerjaNip.Any(e => e.IdPeriode == id);
        }
    }
}
