using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Services.PotrosnjeServisi;

namespace Presentation.Screens
{
    public static class AutentifikacijaScreen
    {
        public static void Prikazi(
            IPotrosaciRepository potrosaciRepo,
            IPotrosnjaServis potrosnjaServis)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Broj ugovora: ");
                var ugovor = Console.ReadLine();
                var korisnik = potrosaciRepo
                    .SviPotrosaci()
                    .FirstOrDefault(p => p.BrPotrosackogUgovora == ugovor);
                if (korisnik != null)
                {
                    MenuScreen.Prikazi(korisnik, potrosaciRepo, potrosnjaServis);
                    return;
                }
                Console.WriteLine("Nepoznat ugovor. Pritisnite ENTER za ponovni pokušaj.");
                Console.ReadLine();
            }
        }
    }
}
