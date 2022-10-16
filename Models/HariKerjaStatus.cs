using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class HariKerjaStatus
    {
        public HariKerjaStatus()
        {
            HariKerjaNip = new HashSet<HariKerjaNip>();
            HariKerja = new HashSet<HariKerja>();

        }

        public int Id { get; set; }
        [Required]
        [StringLength(254)]
        public string Uraian { get; set; }
        public bool Libur { get; set; }

        [InverseProperty("IdHariKerjaStatusNavigation")]
        public virtual ICollection<HariKerjaNip> HariKerjaNip { get; set; }

        [InverseProperty("IdLiburNavigation")]
        public virtual ICollection<HariKerja> HariKerja { get; set; }
    }
}