using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New.Models
{
    public partial class JamKerjaPolaDt
    {
        public int IdPola { get; set; }
        public int IdDow { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan MasukA { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan KeluarA { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan MasukB { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan KeluarB { get; set; }

        [ForeignKey("IdDow")]
        [InverseProperty("JamKerjaPolaDt")]
        public virtual ListHari IdDowNavigation { get; set; }

        [ForeignKey("IdPola")]
        [InverseProperty("JamKerjaPolaDt")]
        public virtual JamKerjaPola IdPolaNavigation { get; set; }
    }
    
}