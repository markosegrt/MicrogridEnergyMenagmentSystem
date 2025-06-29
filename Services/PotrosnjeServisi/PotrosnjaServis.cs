using Domain.Enums;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;
using Services.EvidencijeServisi;


namespace Services.PotrosnjeServisi
{
    public class PotrosnjaServis : IPotrosnjaServis
    {
        private readonly IProizvodnjaServis _proizvodnja;
        IEvidencijaServis? evidencijaServis;
        private readonly IPotrosaciRepository _repo;

        public PotrosnjaServis(IProizvodnjaServis proizvodnja, IPotrosaciRepository repo)//, IEvidencijaServis evidencija
        {
            _proizvodnja = proizvodnja;
            //_evidencija = evidencija;
            _repo = repo;
        }

        public bool ZahtevajPotrosnju(Guid potrosacId, double kolicina)
        {
            double cenaPoKWH = 0;
            var potrosac = _repo.PotrosacPoId(potrosacId);

            if (potrosac == null || string.IsNullOrWhiteSpace(potrosac.ImePrezime))
                return false;

            if (_proizvodnja.ObradiZahtev(kolicina))
            {
                potrosac.UkupnaPotrosnja += kolicina;



                if (potrosac.TipSnabdevanja == Tip_Snabdevanja.KOMERCIJALNO)
                {
                    cenaPoKWH = 43.02;
                    potrosac.TrenutnoZaduzenje += kolicina * cenaPoKWH;
                    evidencijaServis = new EvidencijaUListiServis();
                }
                else if (potrosac.TipSnabdevanja == Tip_Snabdevanja.GARANTOVANO)
                {
                    cenaPoKWH = 22.72;
                    potrosac.TrenutnoZaduzenje += kolicina * cenaPoKWH;
                    evidencijaServis = new EvidencijaUDatoteciServis();
                }
                else
                {
                    evidencijaServis = new EvidencijaUListiServis(); // fallback
                }

                evidencijaServis.Zapisi(kolicina);
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
