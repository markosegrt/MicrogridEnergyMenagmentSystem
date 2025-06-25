using Domain.Enums;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;


namespace Presentation.Screens
{
    public static class UnosPotrosacaScreen
    {
        public static void Prikazi(IPotrosaciRepository repo, IPotrosacServis potrosacServis)
        {
            Console.Clear();

            Console.Write("Ime i prezime: ");
            var ime = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(ime))
            {
                Console.WriteLine("Ime i prezime je obavezno.");
                Console.ReadLine();
                return;
            }

            Console.Write("Broj ugovora: ");
            var ug = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(ug))
            {
                Console.WriteLine("Broj ugovora je obavezan.");
                Console.ReadLine();
                return;
            }

            Console.Write("Tip (1=Komercijalno, 2=Garantovano): ");
            var tInput = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(tInput) || (tInput != "1" && tInput != "2"))
            {
                Console.WriteLine("Neispravan tip snabdevanja.");
                Console.ReadLine();
                return;
            }

            var t = tInput == "2"
                ? Tip_Snabdevanja.GARANTOVANO
                : Tip_Snabdevanja.KOMERCIJALNO;

            var novi = new Potrosac
            {
                JedinstveniId = Guid.NewGuid(),
                ImePrezime = ime,
                BrPotrosackogUgovora = ug,
                TipSnabdevanja = t
            };

            var ok = potrosacServis.DodajNovogPotrosaca(novi);
            Console.WriteLine(ok ? "Potrosac je uspešno dodat." : "Potrosač sa tim ugovorom već postoji.");
            Console.ReadLine();
        }

    }
}
