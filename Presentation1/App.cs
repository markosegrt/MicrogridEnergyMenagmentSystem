using Domain.Repositories.PotrosaciRepositories;
using Domain.Repositories.ProizvodnjaRepositories;
using Domain.Repositories.EvidencijaRepositories;
using Services.SnabdevanjaServisi;
using Services.ProizvodnjeServisi;
using Services.PotrosnjeServisi;
using Services.PotrosacServisi;
using Services.EvidencijeServisi;
using Presentation.Screens;
using Domain.Services;

namespace Presentation
{
    public static class App
    {
        public static void Run()
        {
            Console.Title = "ERS Mikro Mreža";

            // 1) Repozitorijumi
            var potrosaciRepo = new PotrosaciRepository();
            var proizvodnjaRepo = new ProizvodnjaRepository();
            var evidencijaRepo = new EvidencijaRepository();

            // 2) Servisi
            var snabGarant = new GarantovanoSnabdevanjeServis();
            var snabKom = new KomercijalnoSnabdevanjeServis();
            var snabdevanje = snabKom; // može i snabGarant ili switch prema izboru

            var proizvodnjaServis = new ProizvodnjaServis(snabdevanje);
            var evidencijaServis = new EvidencijaUListiServis();  // ili EvidencijaUDatoteciServis
            var potrosnjaServis = new PotrosnjaServis(
                                        proizvodnjaServis,
                                        evidencijaServis,
                                        potrosaciRepo
                                    );
            var potrosacServis = new PotrosacServis();

            // 3) Počni UI
            AutentifikacijaScreen.Prikazi(potrosaciRepo, potrosnjaServis);
        }
    }
}
