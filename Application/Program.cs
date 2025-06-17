using Microsoft.Extensions.DependencyInjection;
using Domain.Models;
using Domain.Enums;
using Domain.Services;
using Services.Snabdevanja;
using Services.Proizvodnje;
using Services.Evidencije;
using Services.OdabirProizvodnje;
using Services.Potrosnje;
using Presentation.Screens;


namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ERS Mikro Mreza";

            // 1. Registracija servisa
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISnabdevanje>(KomercijalnoSnabdevanje._istanca)
                .AddSingleton<IProizvodnja, Proizvodnja>()
                .AddSingleton<IEvidencija, EvidencijaUListi>()
                .AddSingleton<IOdabirProizvodnje, OdabirProizvodnje>()
                .AddSingleton<IPotrosnja, Potrosnja>()
                .BuildServiceProvider();

            // 2. Povuci servise
            var potrosnja = serviceProvider.GetRequiredService<IPotrosnja>();
            var odabir = serviceProvider.GetRequiredService<IOdabirProizvodnje>();
            var proizvodnja = serviceProvider.GetRequiredService<IProizvodnja>();

            // 3. Dodaj demo podatke
            var potrosac = new Potrosac
            {
                JedinstveniId = Guid.NewGuid(),
                ImePrezime = "Milan Nikolić",
                BrPotrosackogUgovora = "UG-001",
                TipSnabdevanja = Tip_Snabdevanja.KOMERCIJALNO
            };

            var sistem = new PodsistemProizvodnje
            {
                Sifra = "NS-001",
                Lokacija = "Novi Sad",
                Tip = Tip_Proizvodnje.ECOGREEN,
                PreostalaKolicina = 1000
            };

            var potrosackiSistem = new PodsistemPotrosnje
            {
                Naziv = "Zona Sever",
                Sifra = "ZS1",
                AktivniPotrosaci = new List<Potrosac> { potrosac }
            };

            odabir.DodajPodsistem(sistem);
            proizvodnja.DodajProizvodniSistem(sistem);
            potrosnja.DodajPotrosackiSistem(potrosackiSistem);

            // 4. Pokreni UI
            AuthScreen.Prikazi(potrosnji: potrosnja, potrosaci: new List<Potrosac> { potrosac });
        }
    }
}