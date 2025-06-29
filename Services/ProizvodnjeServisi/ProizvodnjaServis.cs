using Domain.PomocneMetode;
using Domain.Services;

namespace Services.ProizvodnjeServisi
{
    public class ProizvodnjaServis : IProizvodnjaServis
    {

        private readonly ISnabdevanjeServis _snabdevanje;


        public ProizvodnjaServis(ISnabdevanjeServis snabdevanje)
        {
            _snabdevanje = snabdevanje;
        }

        public bool ObradiZahtev(double kolicina)
        {

            ProveriStanjeElektrana dopuna = new();
            if (dopuna.ProveriStanje())
            {
                _snabdevanje.DopuniEnergiju();
            }
            return _snabdevanje.IzdajEnergiju(kolicina);

        }
    }
}
