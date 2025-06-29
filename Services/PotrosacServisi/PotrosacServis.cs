using Domain.Models;
using Domain.Repositories.PotrosaciRepositories;
using Domain.Services;

namespace Services.PotrosacServisi
{
    public class PotrosacServis : IPotrosacServis
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
