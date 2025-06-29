using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Presentation.Screens
{
    public static class ZahtevZaPotrosnjomScreen
    {
        public static void Prikazi(
            IPotrosaciRepository potrosaciRepo,
            IPotrosnjaServis potrosnjaServis)
        {
            Console.Clear();

            Console.Write("Ime i prezime: ");
            var ime = Console.ReadLine()?.Trim();
            Console.Write("Broj ugovora: ");
            var ugovor = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(ugovor))
            {
                Console.WriteLine("Morate uneti validno ime i broj ugovora.");
                Console.ReadLine();
                return;
            }

            var korisnik = potrosaciRepo
                .SviPotrosaci()
                .FirstOrDefault(p =>
                        string.Equals(p.ImePrezime?.Trim(), ime, StringComparison.OrdinalIgnoreCase) &&
                        p.BrPotrosackogUgovora?.Trim() == ugovor);

            if (korisnik == null)
            {
                Console.WriteLine("Korisnik nije pronađen. Pritisnite ENTER za povratak.");
                Console.ReadLine();
                return;
            }

            Console.Write("Unesite količinu (kWh): ");
            if (!double.TryParse(Console.ReadLine(), out var kolicina) || kolicina <= 0)
            {
                Console.WriteLine("Neispravan unos količine.");
                Console.ReadLine();
                return;
            }

            var ok = potrosnjaServis.ZahtevajPotrosnju(korisnik.JedinstveniId, kolicina);
            Console.WriteLine(ok ? "Zahtev uspešno obrađen." : "Greška pri obradi zahteva.");
            Console.ReadLine();
        }
    }
}
