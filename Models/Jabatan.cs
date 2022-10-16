using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class Jabatan
    {
        public Jabatan()
        {
            PeriodeKaSKPD = new HashSet<PeriodeKaSKPD>();
            PeriodeNIPIdJabatanAtas1Navigation = new HashSet<PeriodeNIP>();
            PeriodeNIPIdJabatanAtas2Navigation = new HashSet<PeriodeNIP>();
            PeriodeNIPIdJabatanNavigation = new HashSet<PeriodeNIP>();
        }

        public int Id { get; set; }
        public int IdUnitKerja { get; set; }
        [Required]
        [StringLength(150)]
        public string Uraian { get; set; }
        public int IdEselon { get; set; }
        public int Urut { get; set; }
        public int IdJabatan { get; set; }
        public int IdAtas { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ValidTill { get; set; }

        [ForeignKey("IdUnitKerja")]
        [InverseProperty("Jabatan")]
        public virtual UnitKerja IdUnitKerjaNavigation { get; set; }
        [InverseProperty("IdJabatanNavigation")]
        public virtual ICollection<PeriodeKaSKPD> PeriodeKaSKPD { get; set; }
        [InverseProperty("IdJabatanAtas1Navigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPIdJabatanAtas1Navigation { get; set; }
        [InverseProperty("IdJabatanAtas2Navigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPIdJabatanAtas2Navigation { get; set; }
        [InverseProperty("IdJabatanNavigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPIdJabatanNavigation { get; set; }
    }
}