using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class JamKerjaPola
    {
        public JamKerjaPola()
        {
            PeriodeNIP = new HashSet<PeriodeNIP>();
            JamKerjaPolaDt = new HashSet<JamKerjaPolaDt>();

        }

        public int Id { get; set; }
        [Required]
        [StringLength(254)]
        public string Uraian { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ValidTill { get; set; }

        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}")]

        //public TimeSpan? MasukA { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        //public TimeSpan? KeluarA { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        //public TimeSpan? MasukB { get; set; }
        //[DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        //public TimeSpan? KeluarB { get; set; }
        //public int? Jumlah { get; set; }
        //public bool Sen { get; set; }
        //public bool Sel { get; set; }
        //public bool Rab { get; set; }
        //public bool Kam { get; set; }
        //public bool Jum { get; set; }
        //public bool Sab { get; set; }
        //public bool Mgg { get; set; }


        [InverseProperty("IdJamKerjaPolaNavigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIP { get; set; }

        [InverseProperty("IdPolaNavigation")]
        public virtual ICollection<JamKerjaPolaDt> JamKerjaPolaDt { get; set; }
    }
}