using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;

namespace Services.Potrosnje
{
    public class Potrosnja : IPotrosnja
    {
        private readonly IProizvodnja _proizvodnja;
        private readonly IEvidencija _evidencija;
        private readonly IOdabirProizvodnje _odabir;
        private readonly List<PodsistemPotrosnje> _podsistemPotrosnje = new();

        public Potrosnja(IProizvodnja proizvodnja, IEvidencija evidencija, IOdabirProizvodnje odabir)
        {
            _proizvodnja = proizvodnja;
            _evidencija = evidencija;
            _odabir = odabir;
        }

        public void DodajPotrosackiSistem(PodsistemPotrosnje sistem)
        {
            _podsistemPotrosnje.Add(sistem);
        }

        public void ZahtevajPotrosnju(Guid potrosacId, double kolicina)
        {
            var potrosac = _podsistemPotrosnje
               .SelectMany(s => s.AktivniPotrosaci)
               .FirstOrDefault(p => p.JedinstveniId == potrosacId);

            if (potrosac == null)
                throw new Exception("Potrosac nije pronadjen.");

            double stvarnaKolicina = _proizvodnja.ObradiZahtev(kolicina);

            // Ažuriranje podataka potrošača
            potrosac.UkupnaPotrosnja += stvarnaKolicina;
            potrosac.TrenutnoZaduzenje += stvarnaKolicina * (potrosac.TipSnabdevanja == Domain.Enums.Tip_Snabdevanja.GARANTOVANO ? 22.72 : 43.02);

            // Evidentiraj
            _evidencija.Zapisi(potrosac, stvarnaKolicina);
        }

        public double VratiZaduzenje(Guid potrosacId)
        {
            var p = _podsistemPotrosnje
                .SelectMany(s => s.AktivniPotrosaci)
                .FirstOrDefault(p => p.JedinstveniId == potrosacId);
            return p?.TrenutnoZaduzenje ?? 0;
        }
    }
}
