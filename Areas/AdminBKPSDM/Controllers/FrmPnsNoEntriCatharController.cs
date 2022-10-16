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

namespace New.Areas.AdminBKPSDM.Controllers
{
    [Area("AdminBKPSDM")]
    public class FrmPnsNoEntriCatharController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;
        private string _idPeriode;
        private int _IdUnitKerja;
        private string _bulan, _tahun,_skpd;

        private readonly IAllRepo<Jabatan> _repoJabatan;
        private readonly IAllRepo<UnitKerja> _repoUnitKerja;
       

        public FrmPnsNoEntriCatharController(IAllRepo<Jabatan> repoJabatan, IAllRepo<UnitKerja> repoUnitKerja,
            ServiceUser varServiceUser, ApplicationDbContext context)
            {
                _repoJabatan = repoJabatan;
                _repoUnitKerja = repoUnitKerja;
                _varServiceUser = varServiceUser;

               _context = context;
               _varServiceUser = varServiceUser;
        }


        // GET: Admin/Jabatan
        public IActionResult Index()
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
                , "Id", "Uraian");

            var row = _repoJabatan.GetAll().ToList();
            // return View(row);

            return View();

        }

        public IActionResult ListPnsNoCathar(NoCatharBKPSDM data)
        {
            _IdUnitKerja = data.Id;
            _idPeriode = data.Periode;
            _bulan = _varServiceUser.GetBulan().ToString();
            _tahun = _varServiceUser.GetTahun().ToString();
            _skpd = _varServiceUser.GetUnitKerja(_IdUnitKerja);

            ViewBag.bulan = _bulan;
            ViewBag.tahun = _tahun;
            ViewBag.periode = _idPeriode;
            ViewBag.skpd = _skpd;

            // var noCathar = _context.Set().FromSql("sp_no_entri_cthar {0},{1}", idUnitKerja, idPeriode);
            var noCathar = _context.noEntriCathar.FromSql("sp_no_entri_cthar {0},{1}", _IdUnitKerja, _idPeriode).ToList();
            return View(noCathar);
        }
    }
}
