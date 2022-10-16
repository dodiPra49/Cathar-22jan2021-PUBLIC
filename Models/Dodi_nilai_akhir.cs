using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public partial class Dodi_nilai_akhir
    {
      
        [Key]
        [StringLength(18)]
        public string id { get; set; }

        [StringLength(7)]
        public string idPeriode { get; set; }

        public int nilai { get; set; }
    }
}






