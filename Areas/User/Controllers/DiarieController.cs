using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using New.Utility;
using New.Repositories;
using FastReport.Utils;
using FastReport.Data;
using FastReport.Web;
using FastReport.Export.PdfSimple;
using FastReport;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;
using System.IO;
using Microsoft.AspNetCore.Mvc.Core;

namespace New.Areas.User.Controllers
{
    [Area("User")]
    public class DiarieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;
        //private readonly SrvFormula _srvFormula;
        private string _idPeriode;
        private string _nip;
        private DateTime _today;
        private readonly IHostingEnvironment _host;
        private DateTime _tanggal;

        public DiarieController(ApplicationDbContext context,
             ServiceUser varServiceUser,
             IHostingEnvironment host
            //,
            // SrvFormula srvFormula
             )
            {
                _context = context;
                _varServiceUser = varServiceUser;
                _host = host;
                //_srvFormula = srvFormula;
            }

        private bool AdaDiPeriodeNip()
            {
                return (_context.PeriodeNIP.Any(u => u.IdPeriode == _idPeriode && u.Nip == _nip));
            }

        // GET: User/Diarie
        public async Task<IActionResult> Index(int id = 0, string ErrorMsg = "" ,int idRapat=0)
        {
            _idPeriode = _varServiceUser.GetPeriode();
            _nip = _varServiceUser.GetUser();
            _today = _varServiceUser.GetToday();

            ViewData["DaftarPeriode"] = new SelectList(_context.Periode.Where(a => a.Aktif == "1"), "Id", "Id");
            ViewData["tanggal"] = DateTime.Now.Date;

            ViewData["periode"] = _varServiceUser.GetPeriode();



            if (!AdaDiPeriodeNip())
                {
                    ViewBag.ErrorMsg = "Belum terdaftar pada periodeNip";
                  //  return RedirectToAction("Index", "Home", new { Area = "SuperAdmin" });
                }

            //return RedirectToAction("GetListAct", new { id = 1 });
            if (ErrorMsg != "")
                {
                    ViewBag.ErrorMsg = ErrorMsg;
                }


            if (_idPeriode == "")
                {
                    ViewBag.ErrorMsg = "Periode belum diset";
                   // return RedirectToAction("Index", "SetPeriode", new { Area = "SuperAdmin" });
                }

            if (!_varServiceUser.PeriodeDalamTanggal(_idPeriode, _today))
                {
                    ViewBag.ErrorMsg = "Periode tidak  dalam tanggal";
                  //  return RedirectToAction("Index", "SetTanggal", new { Area = "SuperAdmin" });
                }


            if (idRapat != 0)
                {
                // var rowList = await _context.Diary.FindAsync(id);
                /*
                var rowListRapat = _context.Rapat
                .Where(u => u.IdPeriode == _idPeriode)
                .Where(u => u.Tanggal == _today)
                //   .Where(u => u.IdUnitKerja == _idUnitKerja)   
                .OrderBy(u => u.WaktuMulai)
                .ToList();
                */

                var rowListRapat = await _context.Rapat.FindAsync(idRapat);
            

                Diary rowList = new Diary
                    {
                        //Id = newId,
                        //IdPeriode = SD.IdPeriode,
                        //Nip = SD.Nip,
                        //Tanggal = SD.Today

                        IdPeriode = _idPeriode,
                        Nip = _nip,
                        Tanggal = _today,
                        Aktifitas=rowListRapat.Aktifitas,
                        WaktuMulai=rowListRapat.WaktuMulai,
                        WaktuHingga=rowListRapat.WaktuHingga,
                        Hasil=rowListRapat.Hasil,
                        Tempat=rowListRapat.Tempat
                    };

                    return View(rowList);
                }   
           

            if (id == 0)
                {
                    Diary rowList = new Diary
                    {
                        //Id = newId,
                        //IdPeriode = SD.IdPeriode,
                        //Nip = SD.Nip,
                        //Tanggal = SD.Today

                        IdPeriode = _idPeriode,
                        Nip = _nip,
                        Tanggal = _today
                    };
                    return View(rowList);
                }
            else
                {
                    var rowList = await _context.Diary.FindAsync(id);
                    return View(rowList);
                }
        }


        public IActionResult Faq()
        {
            return View();
        }

        public async Task<IActionResult> IndexRapat(int id = 0, string ErrorMsg = "")
        {
            _idPeriode = _varServiceUser.GetPeriode();
            _nip = _varServiceUser.GetUser();
            _today = _varServiceUser.GetToday();


            if (!AdaDiPeriodeNip())
            {
                ViewBag.ErrorMsg = "Belum terdaftar pada periodeNip";
                return RedirectToAction("Index", "Home", new { Area = "SuperAdmin" });
            }

            //return RedirectToAction("GetListAct", new { id = 1 });
            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            if (_idPeriode == "")
            {
                ViewBag.ErrorMsg = "Periode belum diset";
                return RedirectToAction("Index", "SetPeriode", new { Area = "SuperAdmin" });
            }

            if (!_varServiceUser.PeriodeDalamTanggal(_idPeriode, _today))
            {
                ViewBag.ErrorMsg = "Periode tidak  dalam tanggal";
                return RedirectToAction("Index", "SetTanggal", new { Area = "SuperAdmin" });
            }


            if (id == 0)
            {
                Rapat rowList = new Rapat
                {
                    //Id = newId,
                    //IdPeriode = SD.IdPeriode,
                    //Nip = SD.Nip,
                    //Tanggal = SD.Today

                    IdPeriode = _idPeriode,
                  //  Nip = _nip,
                    Tanggal = _today
                };
                return View(rowList);
            }
            else
            {
                var rowList = await _context.Rapat.FindAsync(id);
                return View(rowList);
            }
        }





        private int NewId()
        {
            int id = 0;
            var rList = _context.Diary.OrderByDescending(u => u.Id).FirstOrDefault();

            if (rList != null)
            {
                // rList = rList.ToList.t.Take(1);
                id = rList.Id + 1;
            }
            else
            {
                id = 1;
            }
            return (id);
        }


        [HttpPost, ActionName("IndexSave")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(int id,
            string Pilihan,
            [Bind("Id,IdPeriode,Nip,Tanggal,WaktuMulai,WaktuHingga,Aktifitas," +
            "Tempat,Hasil")] Diary diary)
        {
            if (id != diary.Id)
            {
                return NotFound();
            }


            //JIKA STATUS EDIT
            if (id != 0)
            {
                if (ModelState.IsValid)
                {
                    //JIKA STATUS EDIT
                    try
                    {

                        _context.Update(diary);
                        await _context.SaveChangesAsync();
                        //ViewBag.ErrorMsg = SD.msgEdit;
                        return RedirectToAction(nameof(Index), new { id = 0, ErrorMsg = SD.msgEdit });
                        //return RedirectToAction("Index", "Diarie", new { Area = "User" });
                        //return View(diary);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        ViewBag.ErrorMsg = "Gagal menyimpan";
                        return View(diary);
                    }

                }
                else
                {

                    return View(diary);
                }
            }
            //JIKA STATUS ADD
            else
            {
                if (ModelState.IsValid)
                {
                    //JIKA STATUS ADD
                    try
                    {

                        diary.Id = NewId();
                        _context.Add(diary);
                        await _context.SaveChangesAsync();
                        //ViewBag.ErrorMsg = SD.msgSave;
                        //return RedirectToAction(nameof(Index), new { id = 0, ErrorMsg = SD.msgSave });
                        return RedirectToAction("Index", "Diarie", new { Area = "User", ErrorMsg = SD.msgSave });
                        //return View(diary);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        ViewBag.ErrorMsg = "Gagal menyimpan";
                        return View(diary);
                    }

                }
                else
                {
                    return View(diary);
                }
            }
        }



        public IActionResult GetListAct()
        {
            string _iidPeriode = _varServiceUser.GetPeriode();
            string _nnip = _varServiceUser.GetUser();
            DateTime _ttoday = _varServiceUser.GetToday();
            var rowList = _context.Diary
                .Where(u => u.IdPeriode == _iidPeriode)
                .Where(u => u.Nip == _nnip)
                .Where(u => u.Tanggal == _ttoday)
                .OrderBy(u => u.WaktuMulai)
                .ToList();
            //.FirstOrDefault();

            return PartialView("_ListAct", rowList);

        }

        public IActionResult GetListRapat()
        {
            string _idPeriode = _varServiceUser.GetPeriode();
            string _nnip = _varServiceUser.GetUser();
            DateTime _ttoday = _varServiceUser.GetToday();
            int _idUnitKerja=_varServiceUser.GetIdUnitKerja();

            
            var rowList = _context.Rapat
                .Where(u => u.IdPeriode == _idPeriode)
                .Where(u => u.Tanggal == _ttoday)
            //   .Where(u => u.IdUnitKerja == _idUnitKerja)   
                .OrderBy(u => u.WaktuMulai)
                .ToList();

            //.FirstOrDefault();
            //var rowList = _context.Rapat.ToList();

            return PartialView("_ListRapat", rowList);
        }

        // GET: User/Diarie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .Include(d => d.PeriodeNIP)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // GET: User/Diarie/Create
        public IActionResult Create()
        {
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode");
            return View();
        }

        // POST: User/Diarie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPeriode,Nip,Tanggal,WaktuMulai,WaktuHingga,Aktifitas,Tempat,Hasil,WaktuSetuju1,WaktuSetuju2")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", diary.IdPeriode);
            return View(diary);
        }

        // GET: User/Diarie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }
            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", diary.IdPeriode);
            return View(diary);
        }

        // POST: User/Diarie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]


        // GET: User/Diarie/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .Include(d => d.PeriodeNIP)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // POST: User/Diarie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var diary = await _context.Diary.FindAsync(Id);
            _context.Diary.Remove(diary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool DiaryExists(int id)
        {
            return _context.Diary.Any(e => e.Id == id);
        }


        

        // GET: User/Diarie/Edit/5
        public async Task<IActionResult> Ajukan(string idperiode, string nip, string ErrorMsg)
        {
            if (ErrorMsg != "") ViewBag.ErrorMsg = ErrorMsg;
            if (idperiode == "")
            {
                return NotFound();
            }

            var diary = await _context.PeriodeNIP
                .Where(u => u.IdPeriode == idperiode)
                .Where(u => u.Nip == nip)
                .Include(u => u.IdUnitKerjaNavigation)
                .Include(u => u.NipAtas1Navigation)
                .Include(u => u.NipAtas2Navigation)
                .Include(u => u.IdJabatanAtas1Navigation)
                .Include(u => u.IdJabatanAtas2Navigation)
                .Include(u => u.IdJabatanNavigation)
                .Include(u => u.IdJamKerjaPolaNavigation)
                .Include(u => u.NipNavigation)
                .FirstOrDefaultAsync();


            if (diary == null)
            {
                return NotFound();
            }
                        
            int HariKerjaYbsJam = _varServiceUser.GetHKybsJam(idperiode, nip); 
            int DurasiCatHar = _varServiceUser.GetDurasiCatHar(idperiode, nip);
            int Nilai = 0;
            if (HariKerjaYbsJam == 0)
            {
                ViewBag.ErrorMsg = SD.msgErrHKNIP;
            }
            else
            {
                Nilai = (int)((DurasiCatHar * 100) / HariKerjaYbsJam);
            }


            //var Nilai = (int)((DurasiCatHar * 100) / HariKerjaYbsJam);


            var catHarMinus = _varServiceUser.GetCatHarMinus(idperiode, nip);
            var CatHarOverLap = _varServiceUser.GetCatHarOverLap(idperiode, nip);

            ViewBag.HariKalender = _varServiceUser.GetHariKalender();
            ViewBag.HariKerjaYbs = _varServiceUser.GetHKybs(idperiode, nip);
            ViewBag.HariKerjaYbsJam = HariKerjaYbsJam;
            ViewBag.NCatHar = _varServiceUser.GetNCatHar(idperiode, nip);
            ViewBag.DurasiCatHar = DurasiCatHar;

            ViewBag.Nilai = Nilai;

            if (catHarMinus.Count() != 0) ViewBag.CatHarMinus = catHarMinus;
            if (CatHarOverLap.Count() != 0) ViewBag.CatHarOverLap = CatHarOverLap;
            //int a = _varServiceUser.GetNChatHar(idperiode, nip);
            //ViewBag.nCatHar = _varServiceUser.



            ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", diary.IdPeriode);
            return View(diary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ajukan(string idperiode, string nip, string AjukanAtauBatal,
            int? HKYbs, int? DurasiYbs, int? DurasiCatHar,
            [Bind("Ajukan1","Ajukan2")]
            PeriodeNIP periodeNIP)
        {

            if (HKYbs == null) HKYbs = 0;
            if (DurasiYbs == null) DurasiYbs = 0;
            if (DurasiCatHar == null) DurasiCatHar = 0;

            var ajukan = periodeNIP.Ajukan1;
            if (periodeNIP.Ajukan2 != null)
            {
                return RedirectToAction("Ajukan", new { idperiode, nip, ErrorMsg = "Telah di ajukan AL" });
            }

            var row = await _context.PeriodeNIP.Where(u => u.IdPeriode == idperiode && u.Nip == nip).FirstOrDefaultAsync();
            if (AjukanAtauBatal == "Batalkan")
            {
                row.Ajukan1 = null;
                _context.Update(row);
                await _context.SaveChangesAsync();
                return RedirectToAction("Ajukan", new { idperiode, nip, ErrorMsg = "Dibatalkan " });
            }

           
            if (periodeNIP.Ajukan1 == null)
            {

                return RedirectToAction("Ajukan",  new { idperiode, nip, ErrorMsg = "Tanggal pengajuan belum di isi" });
            }

            
            row.Ajukan1 = ajukan;
            row.HKYbs = HKYbs;
            row.DurasiYbs = DurasiYbs;
            row.DurasiCatHar = DurasiCatHar;
            _context.Update(row);
            await _context.SaveChangesAsync();


            return RedirectToAction("Ajukan", new { idperiode, nip, ErrorMsg = "Simpan" });
        }

        public IActionResult Print()
        {

            _idPeriode = _varServiceUser.GetPeriode();
            _nip = _varServiceUser.GetUser();
            var f = _host.ContentRootPath + "\\Reports\\rptCatHarXYZ.frx";
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
            WebReport webReport = new WebReport();
            var iidperiode = _idPeriode;
            var nnip = _nip;
            var nilaiakhir = GetNilaiAkhir(_idPeriode, _nip);
           // var nilaiakhir2 = 99;
            //simpan nilai akhir ke database ->laravel API
           // var empRecord = _context.Database.ExecuteSqlCommand("saveAPICathar {0},{1},{2}", nnip, iidperiode,nilaiakhir);
            //-------END-----

            webReport.Report.Load(f);
            webReport.Report.SetParameterValue("idperiode", iidperiode);
            webReport.Report.SetParameterValue("nip", nnip);
            webReport.Report.SetParameterValue("NilaiAkhir", nilaiakhir);
            ViewBag.WebReport = webReport;
            ViewBag.ErrorMsg = f;

            return View();

        }

        public IActionResult Pdf()
        {
            _idPeriode = _varServiceUser.GetPeriode();
            _nip = _varServiceUser.GetUser();
            var f = _host.ContentRootPath + "\\Reports\\rptCatHarXYZ.frx";
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
            Report report = new Report();
            var iidperiode = _idPeriode;   
            var nnip = _nip;
            var nilaiakhir = GetNilaiAkhir(_idPeriode, _nip);
            report.Report.Load(f);
            report.Report.SetParameterValue("idperiode", iidperiode);
            report.Report.SetParameterValue("nip", nnip);
            report.Report.SetParameterValue("NilaiAkhir", nilaiakhir);
            // persiapkan file report 
            report.Report.Prepare();
            // inline untuk membuat file pdf terbuka di browser
            ContentDisposition contentDisposition = new ContentDisposition
            {
                FileName = "report.pdf",
                Inline = true
            };
            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
            // simpan file kedalam stream 
            Stream stream = new MemoryStream();
            report.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;
            // return stream ke browser  
            return File(stream, "application/pdf");
        }

        private int GetNilaiAkhir( string periode, string nip)
        {
            var retVal = 0;
            var row = _context.PeriodeNIP.Where(u => u.IdPeriode == periode && u.Nip == nip).FirstOrDefault();
            if (row != null )
            {
                if (row.DurasiYbs == null || row.DurasiAAL == null)
                {
                    retVal = 0;
                }
                else
                {
                    retVal = (int)((row.DurasiAAL * 100) / row.DurasiYbs);
                }
            }

            return retVal;
        }

        //public IActionResult Prints()
        //    {
        //        var f = "Reports\\rptCatHar1.frx";

        //        //var f = @"~\Reports\PegawaiBaru.frx";

        //        //string path = Server.MapPath("."); SqlServerReferenceOwnershipBuilderExtensions.Map HttpContext..Current.Request.ApplicationPath;

        //        RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
        //        MsSqlDataConnection sqlConnection = new MsSqlDataConnection();

        //        Report webReport = new Report();
        //        //var iidperiode = "20ww19.15";
        //        var nnip = "19730817200003008";
        //        //webReport.Report.SetParameterValue("idperiode", iidperiode );
        //        webReport.SetParameterValue("Parameter", nnip);
        //        //webReport.Report.SetParameterValue("[Parameter]", nnip);
        //        //webReport.Report.Parameters.se(..SetParameterValue("nnip", "197308172000031008");

        //        webReport.Load(f);
        //        //webReport.prin
        //        ViewBag.WebReport = webReport;

        //        return View();

        //    }

        public ActionResult ModalPopUp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IndexModal([FromBody]SetTglPeriodVM VsetPeriode)
        {

            _idPeriode = VsetPeriode.id;
            _tanggal = VsetPeriode.tanggal;

            if (_idPeriode != "")
            {
                _varServiceUser.SetPeriode(_idPeriode);
            }

            //SET tanggal baru
            string ErrorMSg = "";
            if (_varServiceUser.PeriodeDalamTanggal(_varServiceUser.GetPeriode(), _tanggal))
            {
                ErrorMSg = "Tanggal " + _tanggal.Date.ToShortDateString() + " untuk periode " +
                        _varServiceUser.GetPeriode();

                _varServiceUser.SetToday(_tanggal);
                // return RedirectToAction("Index", "Home", new { ErrorMSg });
            }
            else
            {
                ErrorMSg = "Salah Tanggal!! Periode " + _varServiceUser.GetPeriode();
            }

            //  return Json(System.Web.Mvc.JsonRequestBehavior.AllowGet);
            return Json(new { result = true });

            //   return RedirectToAction("Index", new { ErrorMSg });
        }


    }
    
}

