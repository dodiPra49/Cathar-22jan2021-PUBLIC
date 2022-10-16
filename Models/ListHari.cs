using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class ListHari
    {
        public ListHari()
        {
            JamKerjaPolaDt = new HashSet<JamKerjaPolaDt>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Uraian { get; set; }

        [InverseProperty("IdDowNavigation")]
        public virtual ICollection<JamKerjaPolaDt> JamKerjaPolaDt { get; set; }
    }
}