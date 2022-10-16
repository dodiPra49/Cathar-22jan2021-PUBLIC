using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace New.Models
{
    public class updatepuasaSP
    {
        
        [Key]      
        public int id { get; set; }

        //[StringLength(18, MinimumLength = 18)]
      //  [Required(AllowEmptyStrings =true)]
        public string nip { get; set; }

        [Required]
        public int IdJamKerjaPolaLAMA { get; set; }

        [Required]
        public int IdJamKerjaPolaBARU { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime validTill { get; set; }

        [Required]
        public int JenisUpdate { get; set; }
    }
}
