using Domain.Models;
using Domain.Services;
using Domain.Repositories.PotrosaciRepositories;

namespace Services.PotrosacServisi
{
    public class PotrosacServis:IPotrosacServis
    {
        private readonly IPotrosaciRepository _potrosaci;

        public PotrosacServis(IPotrosaciRepository potrosaci)
        {
            _potrosaci = potrosaci;
        }

        public bool DodajNovogPotrosaca(Potrosac potrosac)
        {
            return _potrosaci.DodajPotrosaca(potrosac);
        }
    }
}
