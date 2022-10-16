using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class HariKerjaNip
    {
        [StringLength(7)]
        public string IdPeriode { get; set; }
        [StringLength(18)]
        public string NIP { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }
        public int IdHariKerjaStatus { get; set; }

        [ForeignKey("IdHariKerjaStatus")]
        [InverseProperty("HariKerjaNip")]
        public virtual HariKerjaStatus IdHariKerjaStatusNavigation { get; set; }

        [ForeignKey("IdPeriode,NIP")]
        [InverseProperty("HariKerjaNip")]
        public virtual PeriodeNIP PeriodeNIP { get; set; }
    }
}