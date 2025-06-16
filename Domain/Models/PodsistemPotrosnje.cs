using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PodsistemPotrosnje
    {
        public string Naziv { get; set; } = string.Empty;
        public string Sifra { get; set; } = string.Empty;
        public List<Potrosac> AktivniPotrosaci { get; set; } = new List<Potrosac>(); 
    }
}
