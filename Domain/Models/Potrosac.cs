using Domain.Enums;

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

        public Potrosac()
        {
        }

        public Potrosac(string imePrezime, string brPotrosackogUgovora, Tip_Snabdevanja tipSnabdevanja, double ukupnaPotrosnja, double trenutnoZaduzenje)
        {
            JedinstveniId = Guid.NewGuid();
            ImePrezime = imePrezime;
            BrPotrosackogUgovora = brPotrosackogUgovora;
            TipSnabdevanja = tipSnabdevanja;
            UkupnaPotrosnja = ukupnaPotrosnja;
            TrenutnoZaduzenje = trenutnoZaduzenje;
        }
    }
}
