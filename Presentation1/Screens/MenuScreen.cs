using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Services.PotrosacServisi;

namespace Presentation.Screens
{
    public static class MenuScreen
    {
        public static void Prikazi(
            Potrosac korisnik,
            IPotrosaciRepository potrosaciRepo,
            IPotrosnjaServis potrosnjaServis)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Dobrodošli, {korisnik.ImePrezime}!");
                Console.WriteLine("1. Unos novog potrošača");
                Console.WriteLine("2. Pregled potrošača");
                Console.WriteLine("3. Zahtev za potrošnjom");
                Console.WriteLine("4. Pregled zaduženja");
                Console.WriteLine("5. Izlaz");
                Console.Write("Izbor: ");
                var izbor = Console.ReadLine();
                switch (izbor)
                {
                    case "1":
                        UnosPotrosacaScreen.Prikazi(potrosaciRepo, potrosacServis: new PotrosacServis());
                        break;
                    case "2":
                        PregledPotrosacaScreen.Prikazi(potrosaciRepo);
                        break;
                    case "3":
                        ZahtevZaPotrosnjomScreen.Prikazi(potrosaciRepo, potrosnjaServis);
                        break;
                    case "4":
                        ZaduzenjeScreen.Prikazi(potrosaciRepo, potrosnjaServis);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Nepoznata opcija. ENTER za ponovo.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
