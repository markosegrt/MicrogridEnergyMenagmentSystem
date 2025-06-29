using Domain.Models;
using Domain.Repositories.ProizvodnjaRepositories;
using Domain.Services;

namespace Services.SnabdevanjaServisi
{
    public class GarantovanoSnabdevanjeServis : ISnabdevanjeServis
    {
        private readonly IProizvodnjaRepository _proizvodnja = new ProizvodnjaRepository();

        public GarantovanoSnabdevanjeServis() { }

        public GarantovanoSnabdevanjeServis(IProizvodnjaRepository proizvodnja)
        {
            _proizvodnja = proizvodnja;
        }

        public bool DopuniEnergiju()
        {
            var proizvodnje = _proizvodnja.Svi();
            foreach (PodsistemProizvodnje p in proizvodnje)
            {
                if (p.PreostalaKolicina < 100)
                {
                    p.PreostalaKolicina += p.PreostalaKolicina * 1.22;
                    return true;
                }
            }
            return false;
        }

        public bool IzdajEnergiju(double kolicina)
        {
            var najbolji = _proizvodnja.Svi().OrderByDescending(s => s.PreostalaKolicina).FirstOrDefault();

            if (najbolji == null)
                return false;

            if (najbolji.PreostalaKolicina >= kolicina)
            {
                najbolji.PreostalaKolicina -= kolicina;
                najbolji.PreostalaKolicina = najbolji.PreostalaKolicina * 0.98;

                return true;
            }

            return false;
        }
    }
}

