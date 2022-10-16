using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
   
namespace New.Models
{
    public partial class NoCatharBKPSDM
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Periode")]
        public string Periode { get; set; }

        [Display(Name = "UNIT KERJA")]
        public string UnitKerja { get; set; }
    }

}
