using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New.Models
{
    public class SetTglPeriodVM
    {
        [Key]
        public string id { get; set; }

        [DataType(DataType.Date)]
        public DateTime tanggal { get; set; }
    }
}

