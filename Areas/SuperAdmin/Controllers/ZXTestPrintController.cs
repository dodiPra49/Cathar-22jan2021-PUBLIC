using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using New.Data;
using New.Models;
using New.Utility;
using New.Repositories;
using FastReport.Utils;
using FastReport.Data;
using FastReport.Web;
using FastReport.Export.PdfSimple;
using FastReport;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mime;
using System.IO;

namespace New.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class ZXTestPrintController : Controller
    {
        private readonly IHostingEnvironment _host;
        public IActionResult ZxTestPrint()
        {
            string f = _host.ContentRootPath + "\\Reports\\pegawai1.frx";
            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
            WebReport webReport = new WebReport();
       
            webReport.Report.Load(f);
            ViewBag.WebReport = webReport;
            ViewBag.ErrorMsg = f;

            return View();

        }
    }
}