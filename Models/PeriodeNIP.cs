using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class PeriodeNIP
    {
        public PeriodeNIP()
        {
            Diary = new HashSet<Diary>();
            HariKerjaNip = new HashSet<HariKerjaNip>();
        }

        [StringLength(7)]
        public string IdPeriode { get; set; }
        [StringLength(18)]
        public string Nip { get; set; }
        public int IdUnitKerja { get; set; }
        public int IdJabatan { get; set; }
        [Required]
        [StringLength(18)]
        public string NipAtas1 { get; set; }
        [Required]
        [StringLength(18)]
        public string NipAtas2 { get; set; }
        public int IdJabatanAtas1 { get; set; }
        public int IdJabatanAtas2 { get; set; }
        public int IdJamKerjaPola { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Ajukan1 { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Ajukan2 { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Selesai { get; set; }
        public int? DurasiYbs { get; set; }
        public int? DurasiCatHar { get; set; }
        public int? DurasiAL { get; set; }
        public int? DurasiAAL { get; set; }
        public int? HKYbs { get; set; }

        [ForeignKey("IdPeriode,IdUnitKerja")]
        [InverseProperty("PeriodeNIP")]
        public virtual PeriodeKaSKPD Id { get; set; }

        [ForeignKey("IdJabatanAtas1")]
        [InverseProperty("PeriodeNIPIdJabatanAtas1Navigation")]
        public virtual Jabatan IdJabatanAtas1Navigation { get; set; }




        [ForeignKey("IdJabatanAtas2")]
        [InverseProperty("PeriodeNIPIdJabatanAtas2Navigation")]
        public virtual Jabatan IdJabatanAtas2Navigation { get; set; }
        [ForeignKey("IdJabatan")]
        [InverseProperty("PeriodeNIPIdJabatanNavigation")]
        public virtual Jabatan IdJabatanNavigation { get; set; }
        [ForeignKey("IdPeriode")]
        [InverseProperty("PeriodeNIP")]
        public virtual Periode IdPeriodeNavigation { get; set; }
        [ForeignKey("IdUnitKerja")]
        [InverseProperty("PeriodeNIP")]
        public virtual UnitKerja IdUnitKerjaNavigation { get; set; }
        [ForeignKey("NipAtas1")]
        [InverseProperty("PeriodeNIPNipAtas1Navigation")]
        public virtual Pegawai NipAtas1Navigation { get; set; }
        [ForeignKey("NipAtas2")]
        [InverseProperty("PeriodeNIPNipAtas2Navigation")]
        public virtual Pegawai NipAtas2Navigation { get; set; }
        [ForeignKey("Nip")]
        [InverseProperty("PeriodeNIPNipNavigation")]
        public virtual Pegawai NipNavigation { get; set; }
        
        [InverseProperty("PeriodeNIP")]
        public virtual ICollection<Diary> Diary { get; set; }
        [InverseProperty("PeriodeNIP")]
        public virtual ICollection<HariKerjaNip> HariKerjaNip { get; set; }
        
        [ForeignKey("IdJamKerjaPola")]
        [InverseProperty("PeriodeNIP")]
        public virtual JamKerjaPola IdJamKerjaPolaNavigation { get; set; }
    }
}