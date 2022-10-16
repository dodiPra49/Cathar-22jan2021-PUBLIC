using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class Periode
    {
        public Periode()
        {
            PeriodeNIP = new HashSet<PeriodeNIP>();
        }

        [StringLength(7)]
        public string Id { get; set; }
        public int? Tahun { get; set; }
        public int? Bulan { get; set; }
        public string Aktif { get; set; }

        [InverseProperty("IdPeriodeNavigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIP { get; set; }
    }
}