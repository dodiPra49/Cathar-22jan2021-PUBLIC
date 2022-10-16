using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class noEntriCathar
    {
        [Key]
        [Display(Name = "NIP.")]
        [StringLength(18)]
        public string NIP { get; set; }

        [Display(Name = "NAMA")]
        [StringLength(50)]
        public string Nama { get; set; }
        
        [Display(Name = "JABATAN")]
        public string Jabatan { get; set; }
    }
}
