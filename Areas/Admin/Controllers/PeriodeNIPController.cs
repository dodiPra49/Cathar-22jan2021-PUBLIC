using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using New.Repositories;
using New.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PeriodeNIPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _SU;
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PeriodeNIPController(ApplicationDbContext context, ServiceUser varServiceUser,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _SU = varServiceUser;
            _userManager = userManager;
        }

        // GET: Admin/PeriodeNIP
        public IActionResult Index(int page = 1, string ErrorMsg = "")
        {
            //var x = SD.IdPeriode;
            if (!_SU.CekPeriodeTanggal())
            {
                ViewBag.ErrorMsg = "Set Periode dan Tanggal Dulu";
                return RedirectToAction("Index", "Home", new { area = "SuperAdmin" });
            }

            var _idperiode = _SU.GetPeriode();
            var _idunit = _SU.GetIdUnitKerja();

            var rowList = _context.PeriodeNIP
               .Where(p => p.IdPeriode == _idperiode)
               .Where(p => p.IdUnitKerja == _idunit)
               .Include(p => p.NipNavigation)
               .Include(p => p.IdJabatanNavigation);

            ViewBag.IdPeriode = _idperiode;
            ViewBag.IdUnit = _idunit;

            if (ErrorMsg != "" && ErrorMsg != null)
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            ViewBag.SemuaAdaUserLogin = SemuaAdaUserLogin(_idperiode, _idunit);
            return View(rowList.GetPaged(page, 15));
        }


        private bool SemuaAdaUserLogin(string idPeriode, int idUnit)
        {
            bool retVal = true;
            var rowList = from p in _context.PeriodeNIP.Where(u => u.IdPeriode == idPeriode)
                          .Where(u => u.IdUnitKerja == idUnit)
                          join a in _context.ApplicationUser on p.Nip equals a.NIP into r
                          from rr in r.DefaultIfEmpty().Where(u => u.NIP == null)
                          select new PeriodeNIP
                          {
                              Nip = p.Nip,
                              IdUnitKerja = idUnit

                          };
            if (rowList.Count() != 0) retVal = false;

            return retVal;

        }

        // GET: Admin/PeriodeNIP/Details/5
        public async Task<IActionResult> Details(string idPeriode, string nip)
        {
            if (idPeriode == null)
            {
                return NotFound();
            }

            var periodeNIP = await _context.PeriodeNIP
                .Include(p => p.Id)
                .Include(p => p.IdJabatanAtas1Navigation)
                .Include(p => p.IdJabatanAtas2Navigation)
                .Include(p => p.IdJabatanNavigation)
                .Include(p => p.IdPeriodeNavigation)
                .Include(p => p.IdUnitKerjaNavigation)
                .Include(p => p.NipAtas1Navigation)
                .Include(p => p.NipAtas2Navigation)
                .Include(p => p.NipNavigation)
                .OrderBy(p => p.IdJabatanNavigation.IdEselon)
                .FirstOrDefaultAsync(m =>
                    m.IdPeriode == idPeriode &&
                    m.Nip == nip);
            if (periodeNIP == null)
            {
                return NotFound();
            }

            return View(periodeNIP);
        }

        // GET: Admin/PeriodeNIP/Create
        public IActionResult Create()
        {
            //if (SD.IdPeriode == null || SD.IdUnit == 0)
            //{
            //    return RedirectToAction("Index", "SetPeriode", new { area = "SuperAdmin" });
            //}

            //ViewData["IdPeriode"] = new SelectList(_context.PeriodeKaSKPD, "IdPeriode", "IdPeriode");
            //ViewData["IdJabatanAtas1"] = new SelectList(_context.Jabatan, "Id", "Uraian");
            //ViewData["IdJabatanAtas2"] = new SelectList(_context.Jabatan, "Id", "Uraian");

            var _nip = _SU.GetUser();
            var _idperiode = _SU.GetPeriode();
            var _cutoff = _SU.GetToday();
            var _idunit = _SU.GetIdUnitKerja();
            ViewData["IdJabatan"] = new SelectList(
                    _context.Jabatan
                    .Where(u => u.IdUnitKerja == _idunit)
                    .Where(u => u.ValidTill == null || u.ValidTill < _cutoff)
                    , "Id", "Uraian");
            ViewData["IdJamKerjaPola"] = new SelectList(
                    _context.JamKerjaPola
                    , "Id", "Uraian");
            //ViewData["IdPeriode"] = new SelectList(_context.Periode, "Id", "Id");
            //ViewData["IdUnitKerja"] = new SelectList(_context.UnitKerja, "Id", "Uraian");
            //ViewData["NipAtas1"] = new SelectList(_context.Pegawai, "NIP", "NIP");
            //ViewData["NipAtas2"] = new SelectList(_context.Pegawai, "NIP", "NIP");
            //ViewData["Nip"] = new SelectList(_context.Pegawai, "NIP", "NIP");

            var rList = new PeriodeNIP()
            {
                IdPeriode = _idperiode,
                //Nip = _nip,
                IdUnitKerja = _idunit
            };

            return View(rList);
        }

        private bool AdaJabatan(int id)
        {
            var retVal = true;
            var rList = _context.Jabatan.Where(u =>
                u.Id == id);
            if (rList == null)
            {
                retVal = false;
            }
            return retVal;
        }

        private bool AdaPegawai(string nip)
        {
            var retVal = true;
            var rList = _context.Pegawai.Where(u =>
                u.NIP == nip);
            if (rList.Count() == 0)
            {
                retVal = false;
            }
            return retVal;
        }

        private string CekReffLink(PeriodeNIP periodeNIP)
        {
            string ErrorReffLink = "";

            //Cek PeriodeNip dengan PeriodeKa SKPD
            var rList1 = _context.PeriodeKaSKPD.Where(u =>
                u.IdPeriode == periodeNIP.IdPeriode &&
                u.IdUnitKerja == periodeNIP.IdUnitKerja);
            if (rList1.Count() == 0) { ErrorReffLink += "Periode dan UnitKerja tidak ditemukan di Periode Ka Unit" + "\n"; }

            //Cek Nip Peg dengan Pegawai
            if (!AdaPegawai(periodeNIP.Nip)) { ErrorReffLink += "PNS tidak ditemukan pada Pegawai" + "\n"; }

            //Cek Nip Atas1 dengan Pegawai
            if (!AdaPegawai(periodeNIP.NipAtas1)) { ErrorReffLink += "Atasan Langsung tidak ditemukan pada Pegawai" + "\n"; }

            //Cek Nip Atas2 dengan Pegawai
            if (!AdaPegawai(periodeNIP.NipAtas2)) { ErrorReffLink += "AL dari Atasan Langsung tidak ditemukan pada Pegawai" + "\n"; }

            //Cek Jabatan Peg 
            if (!AdaJabatan(periodeNIP.IdJabatan)) { ErrorReffLink += "Jabatan Pegawai ybs tidak ditemukan pada Tabel Pegawai" + "\n"; }

            //Cek Jabatan Jabatan AL 
            if (!AdaJabatan(periodeNIP.IdJabatanAtas1)) { ErrorReffLink += "Jabatan Atasan Langsung tidak ditemukan pada Tabel Pegawai" + "\n"; }
            //Cek Jabatan Peg 
            if (!AdaJabatan(periodeNIP.IdJabatanAtas2)) { ErrorReffLink += "Jabatan AL dari Atasan Langsung tidak ditemukan pada Tabel Pegawai" + "\n"; }

            return ErrorReffLink;

        }


        // POST: Admin/PeriodeNIP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriode,Nip,IdUnitKerja,IdJabatan," +
            "NipAtas1,NipAtas2,IdJabatanAtas1,IdJabatanAtas2, IdJamKerjaPola")]
            PeriodeNIP periodeNIP)
        {
            if (periodeNIP.NipAtas1 == null) periodeNIP.NipAtas1 = periodeNIP.Nip;
            if (periodeNIP.NipAtas2 == null) periodeNIP.NipAtas2 = periodeNIP.Nip;

            string ErrorReffLink = "";
            ErrorReffLink = CekReffLink(periodeNIP);
            if (ErrorReffLink != "")
            {
                ViewBag.ErrorReffLink = ErrorReffLink;

            }
            else
            {
                if ((ModelState.IsValid))
                {

                    _context.Add(periodeNIP);
                    await _context.SaveChangesAsync();
                    ViewBag.ErrorMsg = SD.msgSave;
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ViewBag.ErrorMsg = SD.msgErrSave;
                }
            }
            ViewBag.ErrorMsg = SD.msgErrSave;
            var _cutoff = _SU.GetToday();
            var _idunit = _SU.GetIdUnitKerja();

            ViewBag.ErrorReffLink = ErrorReffLink;
            ViewData["IdJabatan"] = new SelectList(
                   _context.Jabatan
                   .Where(u => u.IdUnitKerja == _idunit)
                   .Where(u => u.ValidTill == null || u.ValidTill < _cutoff)
                   , "Id", "Uraian");
            ViewData["IdJamKerjaPola"] = new SelectList(
                    _context.JamKerjaPola
                    , "Id", "Uraian");

            return View(periodeNIP);
        }

        // GET: Admin/PeriodeNIP/Edit/5
        public async Task<IActionResult> Edit(string idPeriode, string nip)
        {
            if (idPeriode == null)
            {
                return NotFound();
            }

            var periodeNIP = await _context.PeriodeNIP
                .Include(p => p.Id)
                .Include(p => p.IdJabatanAtas1Navigation)
                .Include(p => p.IdJabatanAtas2Navigation)
                .Include(p => p.IdJabatanNavigation)
                .Include(p => p.IdPeriodeNavigation)
                .Include(p => p.IdUnitKerjaNavigation)
                .Include(p => p.NipAtas1Navigation)
                .Include(p => p.NipAtas2Navigation)
                .Include(p => p.NipNavigation)
                //.Include(a => a.IdJamKerjaPola)
                .FirstOrDefaultAsync(m =>
                m.IdPeriode == idPeriode &&
                m.Nip == nip);
            if (periodeNIP == null)
            {
                return NotFound();
            }

            var _cutoff = _SU.GetToday();
            var _idunit = _SU.GetIdUnitKerja();

            ViewData["IdJabatan"] = new SelectList(
                    _context.Jabatan
                    .Where(u => u.IdUnitKerja == _idunit)
                    .Where(u => u.ValidTill == null || u.ValidTill > _cutoff)
                    , "Id", "Uraian");

            ViewData["NamaSkpd"] = new SelectList(
                _context.UnitKerja
                .Where(u => u.ValidTill == null || u.ValidTill > _cutoff)
                , "Id", "Uraian");


            ViewData["IdJamKerjaPola"] = new SelectList(
                    _context.JamKerjaPola
                    .Where(u => u.ValidTill == null || u.ValidTill > _cutoff)
                    , "Id", "Uraian");

            return View(periodeNIP);
        }

        // POST: Admin/PeriodeNIP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string idPeriode,
            [Bind("IdPeriode,Nip,IdUnitKerja,IdJabatan,IdJamKerjaPola," +
            "NipAtas1,NipAtas2,IdJabatanAtas1,IdJabatanAtas2")]
            PeriodeNIP periodeNIP)
        {
            var ErrorReffLink = "";
            if (idPeriode != periodeNIP.IdPeriode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ErrorReffLink = CekReffLink(periodeNIP);
                    if (ErrorReffLink == "")
                    {
                        _context.Update(periodeNIP);
                        await _context.SaveChangesAsync();
                        ViewBag.ErrorMsg = SD.msgSave;
                    }
                    else
                    {
                        ViewBag.ErrorMsg = SD.msgErrSave;
                        ViewBag.ErrorReffLink = ErrorReffLink;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodeNIPExists(periodeNIP.IdPeriode, periodeNIP.Nip))
                    {
                        ViewBag.ErrorMsg = "Data tidak ditemukan";
                        return NotFound();
                    }

                }

                return RedirectToAction(nameof(Index), new { ErrorMsg = ViewBag.ErrorMsg });
            }

            var _idunit = _SU.GetIdUnitKerja();
            var _cutoff = _SU.GetToday();
            ViewData["IdJabatan"] = new SelectList(
                    _context.Jabatan
                    .Where(u => u.IdUnitKerja == _idunit)
                    .Where(u => u.ValidTill == null || u.ValidTill < _cutoff)
                    , "Id", "Uraian");
            ViewData["IdJamKerjaPola"] = new SelectList(
                    _context.JamKerjaPola
                    , "Id", "Uraian");

            return View(periodeNIP);
        }

        // GET: Admin/PeriodeNIP/Delete/5
        public async Task<IActionResult> Delete(string idPeriode, string nip)
        {
            if (idPeriode == null)
            {
                return NotFound();
            }

            var periodeNIP = await _context.PeriodeNIP
                .Include(p => p.Id)
                .Include(p => p.IdJabatanAtas1Navigation)
                .Include(p => p.IdJabatanAtas2Navigation)
                .Include(p => p.IdJabatanNavigation)
                .Include(p => p.IdPeriodeNavigation)
                .Include(p => p.IdUnitKerjaNavigation)
                .Include(p => p.NipAtas1Navigation)
                .Include(p => p.NipAtas2Navigation)
                .Include(p => p.NipNavigation)
                .FirstOrDefaultAsync(m => m.IdPeriode == idPeriode );
            if (periodeNIP == null)
            {
                return NotFound();
            }

            return View(periodeNIP);
        }

        // POST: Admin/PeriodeNIP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string idPeriode, string Nip)
        {
            //var ErrorMsg = "";
            if (PeriodeNIPExists(idPeriode, Nip))
            {
                try
                {
                    var periodeNIP = await _context.PeriodeNIP
                    .FirstOrDefaultAsync(m =>
                    m.IdPeriode == idPeriode &&
                    m.Nip == Nip);
                    _context.PeriodeNIP.Remove(periodeNIP);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgDel });
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgErrDel });
                }
            }
            else
            {

                return RedirectToAction(nameof(Index), new { ErrorMsg = SD.msgErrDel });
            }

        }

        private bool PeriodeNIPExists(string idPeriode, string nip)
        {
            return _context.PeriodeNIP.Any(e => e.IdPeriode == idPeriode && e.Nip == nip);
        }


        private int NewId()
        {
            int retVal = 1;
            var rowList = _context.PeriodeNIP.OrderByDescending(u => u.Id).Take(1).FirstOrDefault();
            if (rowList != null)
            {
                retVal += 1;

            }
            return retVal;
        }

        [ActionName("GetIdJabAtas")]
        public IActionResult GetIdJabAtas(int id)
        {
            var retVal = 0;
            var rowList = _context.Jabatan.Where(u => u.Id == id).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.IdAtas;
            }

            return Json(retVal);
        }

        [ActionName("GetIdJabAtas2")]
        public IActionResult GetIdJabAtas2(int idlama, int id)
        {
            var retVal = 0;
            var rowList = _context.Jabatan.Where(u => u.Id == id).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.IdAtas;
            }

            if (rowList.IdAtas == 1 && id != 1)
            {
                rowList = _context.Jabatan.Where(u => u.Id == idlama).FirstOrDefault();
                if (rowList != null)
                {
                    retVal = rowList.IdAtas;
                }
            }
            return Json(retVal);
        }

        [ActionName("GetNamaJab")]
        public IActionResult GetNamaJab(int id)
        {
            var retVal = "";
            var rowList = _context.Jabatan.Where(u => u.Id == id).FirstOrDefault();
            if (rowList != null)
            {
                retVal = rowList.Uraian;
            }

            return Json(retVal);
        }

        public bool AdaUser(string nip)
        {
            bool retVal = false;
            var row = _context.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (row != null) retVal = true;
            return retVal;
        }

        public bool AdaId(string id)
        {
            bool retVal = false;
            var row = _context.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
            if (row != null) retVal = true;
            return retVal;
        }

        public async Task<ActionResult> UserLogins(string idPeriode, int idUnit)
        {

            var rowList = from p in _context.PeriodeNIP.Where(u => u.IdPeriode == idPeriode)
                          .Where(u => u.IdUnitKerja == idUnit)
                          join a in _context.ApplicationUser on p.Nip equals a.NIP into r
                          from rr in r.DefaultIfEmpty().Where(u => u.NIP == null)
                          select new PeriodeNIP
                          {
                              Nip = p.Nip,
                              IdUnitKerja = idUnit
                              //,
                              //ANip = rr.NIP //?? String.Empty
                          };

            var ErrorMsg = "Isi login user selesai";
            string Pass = "User123*";
            string NamaPeg = "";
            var uuser = new ApplicationUser();
            IdentityResult result;
            foreach (PeriodeNIP row in rowList.ToList())
            {
                if (!AdaUser(row.Nip))
                {
                    uuser = new ApplicationUser();
                    NamaPeg = _SU.GetNamaPeg(row.Nip);
                    uuser.NIP = row.Nip;
                    uuser.Nama = NamaPeg;
                    uuser.UserName = row.Nip;
                    uuser.UnitKerja = (short)idUnit;
                    uuser.IdPeriode = idPeriode;

                    if (!_context.ApplicationUser.Any(u => u.Id == uuser.Id))
                    {
                        result = await _userManager.CreateAsync(uuser, Pass);//.GetAwaiter().GetResult();
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(uuser, SD.User);
                        }
                        else
                        {
                            var rowErr = _context.ApplicationUser.FirstOrDefault(u => u.NormalizedUserName == uuser.NIP);
                            ErrorMsg = "Nip " + rowErr.NormalizedUserName + " // " + rowErr.NIP + " telah ada ";
                        }
                    }
                }
            }

            return RedirectToAction(nameof(Index), new { ErrorMsg });
        }

        private string GetIdPerideB4(string idPeriode)
        {
            string retVal = "";
            int BlB4 = 0;
            int ThB4 = 0;
            int BlNow = _SU.GetBulanByPeriode(idPeriode);
            int ThNow = _SU.GetTahunByPeriode(idPeriode);
            if (BlNow == 1)
            {
                BlB4 = 12;
                ThB4 = ThNow - 1;
            }
            else
            {
                BlB4 = BlNow - 1;
                ThB4 = ThNow;
            }
            var row = _context.Periode.Where(u => u.Tahun == ThB4 && u.Bulan == BlB4).FirstOrDefault();
            if (row != null) retVal = row.Id;
            return retVal;

        }

        private void IsiPeriodeKaSKPD(string idPeriodeB4, string idPeriode, int idUnit)
        {
            if (_context.PeriodeKaSKPD.Any(u => u.IdPeriode == idPeriodeB4 && u.IdUnitKerja == idUnit))
            {
                if (!_context.PeriodeKaSKPD.Any(u => u.IdPeriode == idPeriode && u.IdUnitKerja == idUnit))
                {
                    //sumber
                    var row = _context.PeriodeKaSKPD.Where(u => u.IdPeriode == idPeriodeB4).FirstOrDefault();
                    var rowEntry = new PeriodeKaSKPD()
                    {
                        IdPeriode = idPeriode,
                        IdUnitKerja = idUnit,
                        IdJabatan = row.IdJabatan,
                        IdKaSKPD = row.IdKaSKPD
                    };
                    _context.Add(rowEntry);
                    _context.SaveChanges();
                }
            }
        }

        private void IsiPeriodeNip(string idPeriodeB4, string idPeriode, int idUnit)
        {
            if (_context.PeriodeNIP.Any(u => u.IdPeriode == idPeriodeB4 && u.IdUnitKerja == idUnit))
            {
                //sumber
                var rowList = _context.PeriodeNIP.Where(u => u.IdPeriode == idPeriodeB4 && u.IdUnitKerja == idUnit);
                foreach (PeriodeNIP rowEntry in rowList.ToList())
                {
                    if (!_context.PeriodeNIP.Any(u => u.IdPeriode == idPeriode && u.Nip == rowEntry.Nip))
                    {
                        rowEntry.IdPeriode = idPeriode;
                        rowEntry.Ajukan1 = null;
                        rowEntry.Ajukan2 = null;
                        rowEntry.Selesai = null;
                        rowEntry.DurasiAAL = null;
                        rowEntry.DurasiAL = null;
                        rowEntry.DurasiCatHar = null;
                        rowEntry.DurasiYbs = null;
                        rowEntry.HKYbs = null;
                        _context.Add(rowEntry);
                        _context.SaveChanges();

                    }
                }


            }
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
            var tahun = _SU.GetTahunByPeriode(idperiode);
            var bulan = _SU.GetBulanByPeriode(idperiode);
            var rList = _context.HariKerja
                .Where(u => u.Tanggal.Month == bulan)
                .Where(u => u.Tanggal.Year == tahun).ToList();

            foreach (HariKerja row in rList.ToList())
            {
                if (!_context.HariKerjaNip.Any(u => u.IdPeriode == idperiode &&
                    u.NIP == idnip && u.Tanggal == row.Tanggal))
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


        private void IsiHariKerjaNip(string idPeriode, int idUnit)
        {
            var rowList = _context.PeriodeNIP.Where(u => u.IdPeriode == idPeriode && u.IdUnitKerja == idUnit).ToList();


            foreach (PeriodeNIP row in rowList.ToList())
            {
                IsiAllTanggal(row.IdPeriode, row.Nip, row.IdJamKerjaPola);
            }
        }

        public ActionResult ImportPeriodeNip(string idPeriode, int idUnit)
        {
            // cari periode sebelumnya
            string idPeriodeB4 = GetIdPerideB4(idPeriode);
            IsiPeriodeKaSKPD(idPeriodeB4, idPeriode, idUnit);
            IsiPeriodeNip(idPeriodeB4, idPeriode, idUnit);
            IsiHariKerjaNip(idPeriode, idUnit);
            return RedirectToAction(nameof(Index), new { ErrorMsg = "Import selesai" });
        }
    }
}
