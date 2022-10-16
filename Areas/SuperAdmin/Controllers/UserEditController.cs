using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class UserEditController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserEditController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/UserEdit
        public IActionResult Index(int page = 1, string searchString = "#@s",
          string sortOrder = "", string ErrorMsg = "")
        {
            if (searchString != "#@s") ViewBag.searchString = searchString;
            
            ViewData["NipParm"] = String.IsNullOrEmpty(sortOrder) ? "NipDesc" : "";
            ViewData["NamaParm"] = String.IsNullOrEmpty(sortOrder) ? "NamaDesc" : "";

            var rowList = (from c in _context.ApplicationUser
                           .Where( u => u.Nama.Contains(searchString) || u.NIP.Contains(searchString))
                           select c);


            switch (sortOrder)
            {
                case "NipParm":
                    rowList = rowList.OrderBy(u => u.NIP);
                    break;
                case "NamaDesc":
                    rowList = rowList.OrderBy(u => u.Nama);
                    break;
            }

            if (ErrorMsg != "")
            {
                ViewBag.ErrorMsg = ErrorMsg;
            }
            //;
            return View(rowList.GetPaged(page, 15));
        }

        // GET: SuperAdmin/UserEdit/Details/5
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

        //// GET: SuperAdmin/UserEdit/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SuperAdmin/UserEdit/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("NIP,Nama,GelarDepan,GelarBelakang,TempatLahir,TgLLahir,TglPensiun")] Pegawai pegawai)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pegawai);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pegawai);
        //}

        // GET: SuperAdmin/UserEdit/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uuser = _context.ApplicationUser.Where( u => u.NIP  ==  id).FirstOrDefault();
            if (uuser == null)
            {
                return NotFound();
            }
            return View(uuser);
        }

        // POST: SuperAdmin/UserEdit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NIP,Nama,UnitKerja")] ApplicationUser uuser)
        {
            if (id != uuser.NIP)
            {
                return NotFound();
            }

            var usersave = _context.ApplicationUser.Where(u => u.NIP == id).FirstOrDefault();
            usersave.UnitKerja = uuser.UnitKerja;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ApplicationUser.Any( u => u.NIP == uuser.NIP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { searchString = id });
            }
            return View(usersave);
        }

        // GET: SuperAdmin/UserEdit/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uuser = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.NIP == id);
            if (uuser == null)
            {
                return NotFound();
            }

            return View(uuser);
        }

        // POST: SuperAdmin/UserEdit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string NIP)
        {
            var uuser = await _context.ApplicationUser.FirstOrDefaultAsync( u => u.NIP == NIP);
            _context.ApplicationUser.Remove(uuser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { searchString = NIP });
        }
         
    }
}
