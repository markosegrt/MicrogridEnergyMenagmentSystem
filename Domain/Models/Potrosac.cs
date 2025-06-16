using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Potrosac
    {
        // public string JedinstveniId { get; set; } = string.Empty;
        public Guid JedinstveniId { get; set; } = Guid.NewGuid();
        public string ImePrezime { get; set; } = string.Empty;
        public string BrPotrosackogUgovora { get; set; } = string.Empty;
        public Tip_Snabdevanja TipSnabdevanja { get; set; } 
        public double UkupnaPotrosnja { get; set; } = 0; //valjda je podrazumevano 0
        public double TrenutnoZaduzenje { get; set; } = 0;

    }
}
