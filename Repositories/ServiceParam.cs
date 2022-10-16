using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using New.Data;
using New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Repositories
{
    public class ServiceParam
    {
        private readonly ApplicationDbContext _db;

        public ServiceParam(ApplicationDbContext db)
        {
            _db = db;  
        }

        public static void SetIdPeriode(string idPeriode)
        {
            //HttpContext.Session.SetInt32(SD.ssIdUnit, 1);

        }

        public int GetIdUnitKerja(string nip)
        {
            var rowData = _db.ApplicationUser.Where(u => u.UserName == nip).FirstOrDefault();
            if (rowData != null)
            {
                return rowData.UnitKerja;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
