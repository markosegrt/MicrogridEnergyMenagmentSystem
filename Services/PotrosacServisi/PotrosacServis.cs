
using Domain.Models;
using Domain.Services;
using Domain.Repositories.PotrosaciRepositories;

namespace Services.PotrosacServisi
{
    public class PotrosacServis:IPotrosacServis
    {
        private readonly IPotrosaciRepository potrosaci = new PotrosaciRepository();

        public PotrosacServis() { }

        public bool DodajNovogPotrosaca(Potrosac potrosac)
        {
            return potrosaci.DodajPotrosaca(potrosac);
        }
    }
}
