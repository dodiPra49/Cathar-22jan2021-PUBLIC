using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New.Data;
using New.Models;
using New.Utility;

namespace New.Controllers
{
    [Area("SuperAdmin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            if ((HttpContext.Session.GetString(SD.ssNip) != "" &&
                HttpContext.Session.GetString(SD.ssNip) != null))
            {
                string nip = HttpContext.Session.GetString(SD.ssNip);
                var x = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
                HttpContext.Session.SetString(SD.ssNip, nip);
                HttpContext.Session.SetInt32(SD.ssIdUnit, x.UnitKerja);
            }
            else
            {
                HttpContext.Session.SetString(SD.ssNip, "");
                HttpContext.Session.SetInt32(SD.ssIdUnit, 0);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
