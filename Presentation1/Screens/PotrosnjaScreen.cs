using Domain.Models;
using Services.PotrosnjeServisi;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Presentation.Screens
{
    public static class PotrosnjaScreen
    {
        public static void Prikazi(
            Potrosac korisnik,
            IPotrosnjaServis potrosnjaServis,
            IPotrosaciRepository potrosaciRepo)
        {
            Console.Clear();
            Console.Write("Unesite količinu (kWh): ");
            if (!double.TryParse(Console.ReadLine(), out var kolicina) || kolicina <= 0)
            {
                Console.WriteLine("Neispravan unos.");
                Console.ReadLine();
                MenuScreen.Prikazi(korisnik, potrosaciRepo, potrosnjaServis);
                return;
            }

            bool ok = potrosnjaServis.ZahtevajPotrosnju(korisnik.JedinstveniId, kolicina);
            Console.WriteLine(ok ? "Zahtev uspešno obrađen." : "Greška pri obradi zahteva.");
            Console.ReadLine();

            // Sad vraćamo na meni, prosleđujući i repo i servis
            MenuScreen.Prikazi(korisnik, potrosaciRepo, potrosnjaServis);
        }
    }
}
