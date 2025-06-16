using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;


namespace Servisi.Snabdevanja
{
    public class GarantovanoSnabdevanje : ISnabdevanje
    {
        //Ovo radimo da ne bi bilo vise objekata GarantovanoSnabdevanje
        private static readonly GarantovanoSnabdevanje _instanca = new GarantovanoSnabdevanje();
        public static GarantovanoSnabdevanje Instanca => _instanca;

        public double CenaPoKWh => 22.72;

        private GarantovanoSnabdevanje() { }

        public double IzracunajRealnuKolicinu(double zahtevanaKolicina)
        {
            return zahtevanaKolicina * 1.02; // Gubitak 2%
        }

        public string VratiTip()
        {
            return "GARANTOVANO";
        }
    }
}

