using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using FastReport.Utils;
using FastReport.Data;
using FastReport.Web;
using New.ViewModel;    
using System.Security.Claims;
using New.Utility;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using New.Repositories;

namespace New.Areas.AdminBKPSDM
{
    [Area("adminBKPSDM")]
    [Authorize(Roles = SD.AdminBKPSDM)]
    public class PegawaiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PegawaiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/Pegawai
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pegawai.ToListAsync());
        }

        public IActionResult Index2(int page = 1, string searchString = "",
           string sortOrder = "", string ErrorMsg = "")
        {

            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }

            ViewData["NipSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nipdesc" : "";
            ViewData["NamaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "namadesc" : "";
            var p = new PegawaiList();

            var rowList = (from c in _context.Pegawai select c);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                rowList = rowList.Where(c => c.Nama.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nipdesc":
                    rowList = rowList.OrderBy(u => u.TglPensiun).ThenBy(u => u.NIP);
                    break;
                case "namadesc":
                    rowList = rowList.OrderBy(u => u.TglPensiun).ThenBy(u => u.Nama);
                    //rowList = rowList.OrderByDescending(u => u.TglPensiun).ThenBy(u => u.Nama);
                    break;
            }

            return View(rowList.GetPaged(page, 12));
        }


        // GET: SuperAdmin/Pegawai/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.NIP == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // GET: SuperAdmin/Pegawai/Create
        public IActionResult Create(string ErrorMsg)
        {
            ViewBag.ErrorMsg = ErrorMsg;
            return View();
        }

        // POST: SuperAdmin/Pegawai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NIP,Nama,GelarDepan,GelarBelakang,TempatLahir,TgLLahir,TglPensiun")] Pegawai pegawai)
        {
            if (ModelState.IsValid)
            {

                if (PegawaiExists(pegawai.NIP))
                {
                    //return RedirectToAction("Create", new { ErrorMsg = SD.msgErrPK });
                    ViewBag.ErrorMsg = SD.msgErrPKPegawai;
                    //return View(pegawai);
                    return View();

                }
                else
                {
                    _context.Add(pegawai);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", new { ErrorMsg = SD.msgSave });
                    //ViewBag.ErrorMsg = SD.msgSave;
                    //return View(pegawai);
                }
            }

            return View(pegawai);
        }

        // GET: SuperAdmin/Pegawai/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return View(pegawai);
        }

        // POST: SuperAdmin/Pegawai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NIP,Nama,GelarDepan,GelarBelakang,TempatLahir,TgLLahir,TglPensiun")] Pegawai pegawai)
        {
            if (id != pegawai.NIP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pegawai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PegawaiExists(pegawai.NIP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index2), new { ErrorMsg = SD.msgEdit });
            }
            return View(pegawai);
        }

        // GET: SuperAdmin/Pegawai/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.NIP == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // POST: SuperAdmin/Pegawai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Pegawai pegawai)
        {
            //var pegawai = await _context.Pegawai.FindAsync(id);
            //_context.Pegawai.Remove(pegawai);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index2), new { ErrorMsg = SD.msgDel });

            string ErrorReffLink = "";
            ErrorReffLink = CekReffLink(pegawai);
            if (ErrorReffLink != "")
            {
                ViewBag.ErrorReffLink = ErrorReffLink;
            }
            else
            {
                _context.Pegawai.Remove(pegawai);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index2), new { ErrorMsg = SD.msgDel });
            }
            ViewBag.ErrorMsg = SD.msgErrDel;
            ViewBag.ErrorReffLink = ErrorReffLink;
            return View(pegawai);
        }

        private string CekReffLink(Pegawai pegawai)
        {
            string ErrorReffLink = "";

            //Cek Pegawai dengan PeriodeNIP
            var rList1 = _context.PeriodeNIP.Where(u => u.Nip == pegawai.NIP);

            if (rList1.Count() != 0) { ErrorReffLink += "Pegawai tidak bisa dihapus karena terdaftar di PeriodeNip" + "\n"; }

            return ErrorReffLink;
        }

        public async Task<IActionResult> Print()
        {
            var f = "~\\PegawaiBaru.frx";

            //var f = @"~\Reports\PegawaiBaru.frx";

            //string path = Server.MapPath("."); SqlServerReferenceOwnershipBuilderExtensions.Map HttpContext..Current.Request.ApplicationPath;

            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();

            WebReport webReport = new WebReport();

            webReport.Report.SetParameterValue("IdUnitKerja", 12);
            webReport.Report.Load(f);
            ViewBag.WebReport = webReport;

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(await _context.ApplicationUser.Where(u => u.Id != claim.Value).ToListAsync());

        }

        private bool PegawaiExists(string id)
        {
            return _context.Pegawai.Any(e => e.NIP == id);
        }
    }
}
