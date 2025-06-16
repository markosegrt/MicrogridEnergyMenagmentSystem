using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PodsistemProizvodnje
    {
        public string Sifra { get; set; } = string.Empty;
        public Tip_Proizvodnje Tip { get; set; }
        public string Lokacija { get; set; } = string.Empty;
        public double PreostalaKolicina { get; set; }

}
}
