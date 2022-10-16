using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class PeriodeKaSKPD
    {
        public PeriodeKaSKPD()
        {
            PeriodeNIP = new HashSet<PeriodeNIP>();
        }

        [StringLength(7)]
        public string IdPeriode { get; set; }
        public int IdUnitKerja { get; set; }
        public int IdJabatan { get; set; }
        [Required]
        [StringLength(18)]
        public string IdKaSKPD { get; set; }

        [ForeignKey("IdJabatan")]
        [InverseProperty("PeriodeKaSKPD")]
        public virtual Jabatan IdJabatanNavigation { get; set; }
        [ForeignKey("IdKaSKPD")]
        [InverseProperty("PeriodeKaSKPD")]
        public virtual Pegawai IdKaSKPDNavigation { get; set; }
        [InverseProperty("Id")]
        public virtual ICollection<PeriodeNIP> PeriodeNIP { get; set; }
    }
}