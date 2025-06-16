using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;
using Domain.Services;
using Services.Snabdevanja;

namespace Services.Proizvodnje
{
    public class Proizvodnja : IProizvodnja
    {
        private readonly List<PodsistemProizvodnje> _sistemi = new List<PodsistemProizvodnje>();

        private readonly ISnabdevanje _snabdevanje;

        public Proizvodnja(ISnabdevanje snabdevanje)
        {
            _snabdevanje = snabdevanje;
        }

        public void DodajProizvodniSistem(PodsistemProizvodnje podsistemProizvodnje)
        {
            _sistemi.Add(podsistemProizvodnje);
        }

        public double ObradiZahtev(double kolicina)
        {
            var najbolji = _sistemi.Where(s => s.PreostalaKolicina >= kolicina).OrderByDescending(s => s.PreostalaKolicina).FirstOrDefault();

            if (najbolji == null)
                throw new Exception("Nema dovoljno energije");

            double realnaKolicina = _snabdevanje.IzracunajRealnuKolicinu(kolicina);
            najbolji.PreostalaKolicina -= realnaKolicina;

            if (najbolji.PreostalaKolicina < 100)
            {
                if (_snabdevanje.VratiTip() == "GARANTOVANO")
                    najbolji.PreostalaKolicina *= 1.22;
                else
                    najbolji.PreostalaKolicina *= 1.14;
            }


            return kolicina;
        }
    }
}
