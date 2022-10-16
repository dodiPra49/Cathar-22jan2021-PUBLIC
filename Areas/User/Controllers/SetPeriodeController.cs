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
using Microsoft.AspNetCore.Mvc.Core;


namespace New.Areas.User.Controllers
{
    [Area("User")]
    public class SetPeriodeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ServiceUser _varServiceUser;

        private string _idPeriode;
        private DateTime _tanggal;


        public SetPeriodeController(ApplicationDbContext context,
            ServiceUser varServiceUser)
        {
            _context = context;
            _varServiceUser = varServiceUser;
        }

        // GET: SuperAdmin/SetPeriode
        public IActionResult Index()
        {
            ViewData["DaftarPeriode"] = new SelectList(_context.Periode, "Id", "Id");
            ViewData["periode"] = _varServiceUser.GetPeriode();
            return View();
        }

        // Post: SuperAdmin/SetPeriode
        [HttpPost]
        public IActionResult Index(string idPeriode, DateTime Tanggal)
        {
            if (idPeriode != "")
            {
                _varServiceUser.SetPeriode(idPeriode);
                //var rList = _context.ApplicationUser.Where(u => u.NIP == User.Identity.Name).FirstOrDefault();
                //rList.IdPeriode = IdPeriode;
                //_context.Update(rList);
                //_context.SaveChangesAsync();
                //ViewBag.ErrorMsg = SD.msgSave;

                //SD.IdPeriode = IdPeriode;
                //var rowList = _context.Periode.Where(u => u.Id == IdPeriode).FirstOrDefault();
                //if (rowList != null)
                //{
                //    SD.Tahun = rowList.Tahun.GetValueOrDefault();
                //    SD.Bulan = rowList.Bulan.GetValueOrDefault();
                //    string strTgl = SD.Tahun.ToString() + "/" + SD.Bulan.ToString() + "/01";
                //    SD.CutOff  = DateTime.Parse(strTgl.Replace("!", ":"));

                //    //HttpContext.Session.SetInt32(SD.ssTahun, tahun);
                //    //HttpContext.Session.SetInt32(SD.ssBulan, bulan);
                //    //HttpContext.Session.SetString(SD.ssCutOff, tgl.ToString());

                //}
            }

            //Simpan tanggal baru
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
                ErrorMSg = "Salah Tanggal!! Periode " + _varServiceUser.GetPeriode();
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

            //Simpan Tanggal baru -END--


            //   ViewData["DaftarPeriode"] = new SelectList(_context.Periode, "Id", "Id");
            // return RedirectToAction("Index", "Home");
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

   


            return Json(System.Web.Mvc.JsonRequestBehavior.AllowGet);
            // return RedirectToAction("Index", new { ErrorMSg });
        }
    }

    
}
