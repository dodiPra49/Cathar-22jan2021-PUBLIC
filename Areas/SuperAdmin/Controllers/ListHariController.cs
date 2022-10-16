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
    public class ListHariController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListHariController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmin/ListHari
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListHari.ToListAsync());
        }

        // GET: SuperAdmin/ListHari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listHari = await _context.ListHari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listHari == null)
            {
                return NotFound();
            }

            return View(listHari);
        }

        // GET: SuperAdmin/ListHari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/ListHari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Uraian")] ListHari listHari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listHari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listHari);
        }

        // GET: SuperAdmin/ListHari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listHari = await _context.ListHari.FindAsync(id);
            if (listHari == null)
            {
                return NotFound();
            }
            return View(listHari);
        }

        // POST: SuperAdmin/ListHari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Uraian")] ListHari listHari)
        {
            if (id != listHari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listHari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListHariExists(listHari.Id))
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
            return View(listHari);
        }

        // GET: SuperAdmin/ListHari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listHari = await _context.ListHari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listHari == null)
            {
                return NotFound();
            }

            return View(listHari);
        }

        // POST: SuperAdmin/ListHari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listHari = await _context.ListHari.FindAsync(id);
            _context.ListHari.Remove(listHari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListHariExists(int id)
        {
            return _context.ListHari.Any(e => e.Id == id);
        }
    }
}
