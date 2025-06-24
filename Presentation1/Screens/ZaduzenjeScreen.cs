using Domain.Models;
using Services.PotrosnjeServisi;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Presentation.Screens
{
    public static class ZaduzenjeScreen
    {
        public static void Prikazi(
            Potrosac korisnik,
            IPotrosnjaServis potrosnjaServis,
            IPotrosaciRepository potrosaciRepo)
        {
            Console.Clear();
            var iznos = potrosnjaServis.VratiZaduzenje(korisnik.JedinstveniId);
            Console.WriteLine($"Trenutno zaduženje: {iznos} RSD");
            Console.ReadLine();

            MenuScreen.Prikazi(korisnik, potrosaciRepo, potrosnjaServis);
        }
    }
}
