using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NIP { get; set; }
        public Int16 UnitKerja { get; set; }
        public string Nama { get; set; }
        public string IdPeriode { get; set; }
        public DateTime? Tanggal { get; set; }
    }
}
