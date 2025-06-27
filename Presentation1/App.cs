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

            //Repozitorijumi
            var potrosaciRepo = new PotrosaciRepository();
            var proizvodnjaRepo = new ProizvodnjaRepository();
            var evidencijaRepo = new EvidencijaRepository();

            //Servisi
            var snabGarant = new GarantovanoSnabdevanjeServis();
            var snabKom = new KomercijalnoSnabdevanjeServis();
            var snabdevanje = snabKom;

            var proizvodnjaServis = new ProizvodnjaServis(snabdevanje);
            //var evidencijaServis = new EvidencijaUListiServis();  // ili EvidencijaUDatoteciServis
            var potrosnjaServis = new PotrosnjaServis(
                                        proizvodnjaServis,
                                        //evidencijaServis,
                                        potrosaciRepo
                                    );
            var potrosacServis = new PotrosacServis(potrosaciRepo);

            // 3) Počni UI
            AutentifikacijaScreen.Prikazi(potrosaciRepo, potrosnjaServis);
        }
    }
}
