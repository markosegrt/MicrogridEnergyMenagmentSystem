using Domain.Models;
using Domain.Services;

namespace Presentation.Screens
{
    public static class ZahtevScreen
    {
        public static void Prikazi(
            Potrosac korisnik,
            IPotrosnjaServis potrosnjaServis)
        {
            Console.Clear();
            Console.Write("kW: ");
            if (double.TryParse(Console.ReadLine(), out var k) && k > 0)
            {
                var ok = potrosnjaServis.ZahtevajPotrosnju(korisnik.JedinstveniId, k);
                Console.WriteLine(ok ? "Izdato." : "Nedovoljno.");
            }
            else Console.WriteLine("Neispravan unos.");
            Console.ReadLine();
        }
    }
}
