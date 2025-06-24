using Domain.Enums;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;


namespace Services.PotrosnjeServisi
{
    public class PotrosnjaServis : IPotrosnjaServis
    {
        private readonly IProizvodnjaServis _proizvodnja;
        private readonly IEvidencijaServis _evidencija;
        private readonly IPotrosaciRepository _repo;

        public PotrosnjaServis(IProizvodnjaServis proizvodnja, IEvidencijaServis evidencija, IPotrosaciRepository repo)
        {
            _proizvodnja = proizvodnja;
            _evidencija = evidencija;
            _repo = repo;
        }

        public bool ZahtevajPotrosnju(Guid potrosacId, double kolicina)
        {
            double cenaPoKWH = 0;
            var potrosac = _repo.PotrosacPoId(potrosacId);

            if (potrosac == null || potrosac.ImePrezime == string.Empty)
                return false;

            if (_proizvodnja.ObradiZahtev(kolicina))//njema vraca bool a tebi kolicinu
            {
                potrosac.UkupnaPotrosnja += kolicina;

                if(potrosac.TipSnabdevanja == Tip_Snabdevanja.KOMERCIJALNO)
                {
                    cenaPoKWH = 43.02;
                    potrosac.TrenutnoZaduzenje += kolicina * cenaPoKWH;

                    _evidencija.Zapisi(kolicina);

                }
                else if(potrosac.TipSnabdevanja == Tip_Snabdevanja.GARANTOVANO)
                {
                    cenaPoKWH = 22.72;
                    potrosac.TrenutnoZaduzenje += kolicina * cenaPoKWH;

                    _evidencija.Zapisi(kolicina);
                }

                return true;
            }
            return false;
        }

        public double VratiZaduzenje(Guid potrosacId)
        {
            var potrosac = _repo.PotrosacPoId(potrosacId);
            return potrosac?.TrenutnoZaduzenje ?? 0; //Vraca trenutno zaduzenje ako nije null ako jeste vraca 0
        }
    }
}
