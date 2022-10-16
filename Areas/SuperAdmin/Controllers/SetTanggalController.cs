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
using New.Utility;
using New.Repositories;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class SetTanggalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;

        public SetTanggalController(ApplicationDbContext context,
            ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        // GET: SuperAdmin/SetTanggal
        public IActionResult Index(string ErrorMsg = "")
        {
            ViewBag.ErrorMsg = ErrorMsg;
           return View(DateTime.Now.Date);
          
        }

        // POST: SuperAdmin/SetTanggal
        [HttpPost]
        public IActionResult Index(DateTime Tanggal)
        {
            string ErrorMSg = "";
            if (_varServiceUser.PeriodeDalamTanggal(_varServiceUser.GetPeriode(), Tanggal))
            {
                ErrorMSg = "Tanggal " + Tanggal.Date.ToShortDateString() + " untuk periode " +
                        _varServiceUser.GetPeriode();

                _varServiceUser.SetToday(Tanggal);
                return RedirectToAction("Index", "Home", new { ErrorMSg });
            }
            else
            {
                ErrorMSg = "Salah Tanggal!! Periode " + _varServiceUser.GetPeriode() ;
            }
            //if TanggalDalamPeriode
            //{
            //    var rList = _context.ApplicationUser.Where(u => u.NIP == User.Identity.Name).FirstOrDefault();
            //    rList.Tanggal = Tanggal;
            //    _context.Update(rList);
            //    _context.SaveChangesAsync();

            //    return RedirectToAction("Index", "Home");
            //}
            //DateTime tgl = _varServiceUser.GetToday();
            //string periode = _varServiceUser.GetPeriode();
            //var ErrorMSg = "Tanggal " + tgl.Date.ToShortDateString() + " untuk periode " +
            //    _varServiceUser.GetPeriode();

            return RedirectToAction("Index", new { ErrorMSg });
        }

        private bool TanggalDalamPeriode(string idPeriode, DateTime tanggal)
        {
            var rList = _context.Periode.Where(u => u.Id == idPeriode).FirstOrDefault();

            if (rList != null)
            {
                if (tanggal.Month != rList.Bulan && tanggal.Year != rList.Tahun)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            return false;
        }

    }
}
