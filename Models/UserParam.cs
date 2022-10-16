using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace New.Models
{
    public class UserParam
    {
        public string Nip { get; set; }
        public string Nama { get; set; }
        public string Periode { get; set; }
        public int Tahun { get; set; }
        public int Bulan { get; set; }
        public int IdUnit { get; set; }
        public DateTime? CutOff { get; set; }
    }
}
