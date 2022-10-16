using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class Pegawai
    {
        public Pegawai()
        {
            PeriodeKaSKPD = new HashSet<PeriodeKaSKPD>();
            PeriodeNIPNipAtas1Navigation = new HashSet<PeriodeNIP>();
            PeriodeNIPNipAtas2Navigation = new HashSet<PeriodeNIP>();
            PeriodeNIPNipNavigation = new HashSet<PeriodeNIP>();
        }

        [Key]
        [StringLength(18)]
        public string NIP { get; set; }
        [Required]
        [StringLength(50)]
        public string Nama { get; set; }
        [StringLength(8)]
        public string GelarDepan { get; set; }
        [StringLength(25)]
        public string GelarBelakang { get; set; }
        [Required]
        [StringLength(30)]
        public string TempatLahir { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? TgLLahir { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? TglPensiun { get; set; }

        [InverseProperty("IdKaSKPDNavigation")]
        public virtual ICollection<PeriodeKaSKPD> PeriodeKaSKPD { get; set; }
        [InverseProperty("NipAtas1Navigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPNipAtas1Navigation { get; set; }
        [InverseProperty("NipAtas2Navigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPNipAtas2Navigation { get; set; }
        [InverseProperty("NipNavigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIPNipNavigation { get; set; }
    }
}