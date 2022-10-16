using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class HariKerja
    {

        [Key]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }
        public int IdLibur { get; set; }

        [ForeignKey("IdLibur")]
        [InverseProperty("HariKerja")]
        public virtual HariKerjaStatus IdLiburNavigation { get; set; }
    }
}