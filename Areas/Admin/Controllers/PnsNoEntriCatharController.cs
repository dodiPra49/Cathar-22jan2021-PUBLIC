using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Utility;
using New.Repositories;
using FastReport.Utils;
using New.Models;


namespace New.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PnsNoEntriCatharController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;
        private string _idPeriode;
        private string _IdUnitKerja;
        private string _bulan, _tahun;



        public PnsNoEntriCatharController(ApplicationDbContext context, ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }


      
        public async Task<IActionResult> Index()
        {
            
            _IdUnitKerja= _varServiceUser.GetIdUnitKerja().ToString();
            _idPeriode = _varServiceUser.GetPeriode();
            _bulan = _varServiceUser.GetBulan().ToString()
;            _tahun = _varServiceUser.GetTahun().ToString();

            ViewBag.bulan = _bulan;
            ViewBag.tahun = _tahun;

            // var noCathar = _context.Set().FromSql("sp_no_entri_cthar {0},{1}", idUnitKerja, idPeriode);
            var noCathar = _context.noEntriCathar.FromSql("sp_no_entri_cthar {0},{1}", _IdUnitKerja,_idPeriode).ToList();
            return View(noCathar);
        }
      
        /*
        public async Task<IActionResult> listNoCathar(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            /*
            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return View(pegawai);
          var pegawai = await _context.Pegawai.FindAsync(id);

            if (pegawai == null)
                {
                    return NotFound();
                }
             return View(pegawai);
        }
        */

        private bool PegawaiExists(string id)
        {
            return _context.Pegawai.Any(e => e.NIP == id);
        }
    }
}
