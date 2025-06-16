using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Snabdevanja
{
    internal class KomercijalnoSnabdevanje : ISnabdevanje
    {
        private static readonly KomercijalnoSnabdevanje _istanca = new KomercijalnoSnabdevanje();

        public static KomercijalnoSnabdevanje Istanca => _istanca;

        public double CenaPoKWh => 43.02;

        private KomercijalnoSnabdevanje() { }

        public double IzracunajRealnuKolicinu(double zahtevanaKolicina)
        {
            return zahtevanaKolicina * 1.01; //gubitak 1 posto
        }

        public string VratiTip()
        {
            return "KOMERCIJALNO";
        }
       
    }
}
