using Domain.Enums;

namespace Domain.Models
{
    public class PodsistemProizvodnje
    {
        public string Sifra { get; set; } = string.Empty;
        public Tip_Proizvodnje Tip { get; set; }
        public string Lokacija { get; set; } = string.Empty;
        public double PreostalaKolicina { get; set; }

        public PodsistemProizvodnje()
        {
        }

        public PodsistemProizvodnje(string sifra, Tip_Proizvodnje tip, string lokacija, double preostalaKolicina)
        {
            Sifra = sifra;
            Tip = tip;
            Lokacija = lokacija;
            PreostalaKolicina = preostalaKolicina;
        }
    }
}
