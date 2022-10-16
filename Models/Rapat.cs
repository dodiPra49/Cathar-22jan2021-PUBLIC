using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class Rapat
    {
        public int Id { get; set; }
        [Required]
        [StringLength(7)]
        public string IdPeriode { get; set; }
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
        [Required]
        public int IdUnitKerja { get; set; }
        [Required]
        public bool Level { get; set; }

    }
}