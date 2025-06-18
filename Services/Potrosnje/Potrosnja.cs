using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Services.Potrosnje
{
    public class Potrosnja : IPotrosnja
    {
        private readonly IProizvodnja _proizvodnja;
        private readonly IEvidencija _evidencija;
        private readonly IOdabirProizvodnje _odabir;
        private readonly List<PodsistemPotrosnje> _podsistemPotrosnje = new();

        // ovde ide repo za podsisteme potrosnje
        IPotrosaciRepository repo = new PotrosaciRepository();

        public Potrosnja(IProizvodnja proizvodnja, IEvidencija evidencija, IOdabirProizvodnje odabir)
        {
            _proizvodnja = proizvodnja;
            _evidencija = evidencija;
            _odabir = odabir;
        }

        public bool DodajPotrosackiSistem(PodsistemPotrosnje sistem)
        {
            // povratna vrednost metode da bude bool

            // i pozivas metode iz repo
            return repo.DodajPotrosaca(potrosac);
           // _podsistemPotrosnje.Add(sistem);
        }

        // povratna vrednost npr double, -1 znaci da potrosac ne postoji npr
        // a ne negativna vrendnost klk je potrosio
        public void ZahtevajPotrosnju(Guid potrosacId, double kolicina)
        {
            // koristis repo
            Potrosac trazeni = repo.PotrosacPoId(potrosacId);

            if (trazeni.ImePrezime == string.Empty)
                return -1;

            return trazeni.UkupnaPotrosnja;

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
