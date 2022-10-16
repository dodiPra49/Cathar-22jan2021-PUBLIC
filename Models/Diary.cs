using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class Diary
    {
        public int Id { get; set; }
        [Required]
        [StringLength(7)]
        public string IdPeriode { get; set; }
        [Required]
        [StringLength(18)]
        public string Nip { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }
        [Required, DataType(System.ComponentModel.DataAnnotations.DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "23:59")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan WaktuMulai { get; set; }
        [Required, DataType(System.ComponentModel.DataAnnotations.DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "23:59")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan WaktuHingga { get; set; }
        [Required]
        [MaxLength]
        public string Aktifitas { get; set; }
        [Required]
        [MaxLength]
        public string Tempat { get; set; }
        [Required]
        [MaxLength]
        public string Hasil { get; set; }
        public int? WaktuSetuju1 { get; set; }
        public int? WaktuSetuju2 { get; set; }

        [ForeignKey("IdPeriode,Nip")]
        [InverseProperty("Diary")]
        public virtual PeriodeNIP PeriodeNIP { get; set; }
    }
}