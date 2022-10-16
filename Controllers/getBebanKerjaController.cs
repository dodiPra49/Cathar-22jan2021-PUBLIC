
using System.Collections.Generic;
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

namespace New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getBebanKerjaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public  getBebanKerjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "API Nilai SiCathar", "Parameter->NIP/PERIODE" };
        }




        // GET: api/getBebanKerja/5
        //  [HttpGet("{id}", Name = "Get")]

        [HttpGet("{id}/{idPeriode}", Name = "Get")]
        public int Get(string id,string idPeriode)
        {
            var nilaiBebanKerja= GetNilaiAkhir(idPeriode,id);
          //  nilaiBebanKerja = 98;
            return nilaiBebanKerja;
        }

        private int GetNilaiAkhir(string periode, string nip)
        {
            var retVal = 0;
            var row = _context.PeriodeNIP.Where(u => u.IdPeriode == periode && u.Nip == nip).FirstOrDefault();
            if (row != null)
            {
                if (row.DurasiYbs == null || row.DurasiAAL == null)
                {
                    retVal = 0;
                }
                else
                {
                    retVal = (int)((row.DurasiAAL * 100) / row.DurasiYbs);
                }
            }

            return retVal;
        }
    }
}
