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

namespace New.Areas.User.Controllers
{
    [Area("User")]
    public class PenilaianALController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _su;
        private string _idPeriode;
        private string _nip;
        private DateTime _today;

        public PenilaianALController(ApplicationDbContext context, ServiceUser su)
        {
            _context = context;
            _su = su;
        }

        // GET: User/PenilaianAL
        public async Task<IActionResult> Index()
        {
            _idPeriode = _su.GetPeriode();
            _nip = _su.GetUser();
            _today = _su.GetToday();

            var applicationDbContext = _context.PeriodeNIP
                .Where(p => p.IdPeriode == _idPeriode && p.NipAtas1 == _nip)
                .Include(p => p.Id)
                .Include(p => p.IdJabatanAtas1Navigation)
                .Include(p => p.IdJabatanAtas2Navigation)
                .Include(p => p.IdJabatanNavigation)
                .Include(p => p.IdJamKerjaPolaNavigation)
                .Include(p => p.IdPeriodeNavigation)
                .Include(p => p.IdUnitKerjaNavigation)
                .Include(p => p.NipAtas1Navigation)
                .Include(p => p.NipAtas2Navigation)
                .Include(p => p.NipNavigation);
            return View(await applicationDbContext.ToListAsync());
        }


        public IActionResult Pilih(string idperiode, string nip)
        {

            var rows = _context.Diary.Where(u => u.IdPeriode == idperiode && u.Nip == nip)
                    .OrderBy(u => u.Tanggal).ThenBy(u => u.WaktuMulai).ToList();

            var periodenip = _context.PeriodeNIP.Where(u => u.IdPeriode == idperiode && u.Nip == nip).FirstOrDefault();
            if (periodenip.Ajukan2 != null)
            {
                ViewBag.Ajukan2 = periodenip.Ajukan2;
            }
            return View(rows);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pilih(DateTime Ajukan2,
            [Bind("Id,IdPeriode,Nip,WaktuSetuju1")]
            List<AjukanDiary> list)
        {

            foreach (var i in list)
            {
                var c = _context.Diary.Where(u => u.Id == i.Id).FirstOrDefault();
                if (c != null)
                {
                    c.WaktuSetuju1 = i.WaktuSetuju1;
                    _context.Update(c);
                    _context.SaveChanges();
                }
            }
            if (list != null)
            {
                var idperiode = list[0].IdPeriode;
                var nip = list[0].Nip;
                var periodenip = _context.PeriodeNIP.Where(u => u.IdPeriode == idperiode && u.Nip == nip).FirstOrDefault();
                if (periodenip != null)
                {
                    int DurasiAL = _su.GetDurasiAL(idperiode, nip);
                    periodenip.DurasiAL = DurasiAL;
                    periodenip.Ajukan2 = Ajukan2;
                    _context.Update(periodenip);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> GetHeaderAL(int id)
        {
            string idperiode = "";
            string nip = "";
            var row = await _context.Diary.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (row != null)
            {
                idperiode = row.IdPeriode;
                nip = row.Nip;
            }

            var periodenip = await _context.PeriodeNIP
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


            if (periodenip == null)
            {
                return NotFound();
            }

            int HariKerjaYbsJam = _su.GetHKybsJam(idperiode, nip);
            int DurasiCatHar = _su.GetDurasiCatHar(idperiode, nip);
            int Nilai = (int)((DurasiCatHar * 100) / HariKerjaYbsJam);
            var catHarMinus = _su.GetCatHarMinus(idperiode, nip);
            var CatHarOverLap = _su.GetCatHarOverLap(idperiode, nip);
            int DurasiAL = _su.GetDurasiAL(idperiode, nip);
            int DurasiAAL = _su.GetDurasiAAL(idperiode, nip);

            ViewBag.DurasiAL = DurasiAL;
            ViewBag.DurasiAAL = DurasiAAL;
            int NilaiAL = 0;
            int NilaiAAL = 0;
            if (DurasiAL != 0) NilaiAL = (int)((DurasiAL * 100) / HariKerjaYbsJam);
            if (DurasiAAL != 0) NilaiAAL = (int)((DurasiAAL * 100) / HariKerjaYbsJam);

            ViewBag.NilaiAL = NilaiAL;
            ViewBag.NilaiAAL = NilaiAAL;
            ViewBag.HariKalender = _su.GetHariKalender();
            ViewBag.HariKerjaYbs = _su.GetHKybs(idperiode, nip);
            ViewBag.HariKerjaYbsJam = HariKerjaYbsJam;
            ViewBag.NCatHar = _su.GetNCatHar(idperiode, nip);
            ViewBag.DurasiCatHar = DurasiCatHar;

            ViewBag.Nilai = Nilai;

            //if (catHarMinus.Count() != 0) ViewBag.CatHarMinus = catHarMinus;
            //if (CatHarOverLap.Count() != 0) ViewBag.CatHarOverLap = CatHarOverLap;
            //int a = _varServiceUser.GetNChatHar(idperiode, nip);
            //ViewBag.nCatHar = _varServiceUser.



            //ViewData["IdPeriode"] = new SelectList(_context.PeriodeNIP, "IdPeriode", "IdPeriode", diary.IdPeriode);



            return PartialView("_HeaderAL", periodenip);


        }
    }
}


//public async Task<IActionResult> Pilih(List<Diary> list)
//{

//    foreach (var i in list)
//    {
//        var c = await _context.Diary.Where(u => u.Id == i.Id).FirstOrDefaultAsync();
//        if (c != null)
//        {
//            c.WaktuSetuju1 = i.WaktuSetuju1;
//            _context.Update(c);
//            await _context.SaveChangesAsync();
//        }
//    }

//    ViewBag.Message = "Successfully Updated.";
//    return View(list);

//}
