using Domain.Enums;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;


namespace Presentation.Screens
{
    public static class UnosPotrosacaScreen
    {
        public static void Prikazi(
            IPotrosaciRepository repo,
            IPotrosacServis potrosacServis)
        {
            Console.Clear();
            Console.Write("Ime i prezime: ");
            var ime = Console.ReadLine();
            Console.Write("Broj ugovora: ");
            var ug = Console.ReadLine();
            Console.Write("Tip (1=Komercijalno, 2=Garantovano): ");
            var t = Console.ReadLine() == "2"
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
            Console.WriteLine(ok ? "Dodat." : "Već postoji.");
            Console.ReadLine();
        }
    }
}
