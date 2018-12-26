using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Models
{
    public class Ablamm2018
    {
        [Key]
        public int ablammId { get; set; }
        public string schaf_nr { get; set; }
        public int lfd_nr { get; set; }
        public DateTime? zum_widder_datum { get; set; }
        public DateTime? ablamm_datum { get; set; }
        public DateTime? abspaenn_datum { get; set; }
        public string lamm1_nr { get; set; }
        public string lamm2_nr { get; set; }
        public string lamm3_nr { get; set; }
        public string widder_nr { get; set; }
        public string bemerkung { get; set; }
    }
}
