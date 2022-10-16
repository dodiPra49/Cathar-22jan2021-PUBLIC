using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class UnitKerja
    {
        public UnitKerja()
        {
            Jabatan = new HashSet<Jabatan>();
            PeriodeNIP = new HashSet<PeriodeNIP>();
        }

        public static object SelectedItem { get; internal set; }
        public int Id { get; set; }
        [Required]
        [Column("Uraian")]
        [StringLength(200)]
        public string Uraian { get; set; }
        public int IdLevel { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? ValidTill { get; set; }

        [InverseProperty("IdUnitKerjaNavigation")]
        public virtual ICollection<Jabatan> Jabatan { get; set; }
        [InverseProperty("IdUnitKerjaNavigation")]
        public virtual ICollection<PeriodeNIP> PeriodeNIP { get; set; }
    }
}