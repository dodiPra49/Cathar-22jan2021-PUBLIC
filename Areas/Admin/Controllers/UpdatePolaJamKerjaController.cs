using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using New.Data;
using New.Models;

namespace New.Areas.Admin
{
    [Area("Admin")]
    public class UpdatePolaJamKerjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpdatePolaJamKerjaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult updatePuasaSP()
        {
            List<SelectListItem> JenisUpdate = new List<SelectListItem>()
           {
                new SelectListItem {
                    Text = "Perorangan", Value = "0"
                },
                new SelectListItem {
                    Text = "Per Kelompok", Value = "1"
                },
           };

            ViewBag.cboJenisUpdate = JenisUpdate;
            ViewData["PolaJamKerja"] = new SelectList(_context.JamKerjaPola, "Id", "Uraian");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePuasaSP(updatepuasaSP data)
        {
            //  var empRecord = _context.Database.ExecuteSqlCommand("updatePuasaSPxx {0},{1},{2},{3},{4}",nip,polaLama,polaBaru,tanggal,jenis );
            var nip = data.nip;
            var lama = data.IdJamKerjaPolaLAMA;
            var baru = data.IdJamKerjaPolaBARU;
            var tanggal = data.validTill;
            var jenis = data.JenisUpdate;


            var empRecord = _context.Database.ExecuteSqlCommand("updatePuasaSP {0},{1},{2},{3},{4}", nip, lama, baru, tanggal, jenis);
         
            return View();
        }
    }
}