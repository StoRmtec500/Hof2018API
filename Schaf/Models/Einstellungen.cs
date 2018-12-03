using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Models
{
    public class Einstellungen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int einstellungenID { get; set; }
        public string name { get; set; }
        public string wert { get; set; }
    }
}
