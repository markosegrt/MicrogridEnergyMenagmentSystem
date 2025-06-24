namespace Domain.Models
{
    public class PodsistemPotrosnje
    {
        public string Naziv { get; set; } = string.Empty;
        public string Sifra { get; set; } = string.Empty;

        public PodsistemPotrosnje()
        {
        }

        public PodsistemPotrosnje(string naziv, string sifra)
        {
            Naziv = naziv;
            Sifra = sifra;
            
        }
    }
}
