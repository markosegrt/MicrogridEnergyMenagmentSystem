using Domain.Models;
using Domain.Repositories.ProizvodnjaRepositories;

namespace Domain.PomocneMetode
{
    public class ProveriStanjeElektrana
    {
        private readonly IProizvodnjaRepository _proizvodnjaRepository = new ProizvodnjaRepository();

        public bool ProveriStanje()
        {
            var proizvodnja = _proizvodnjaRepository.Svi();
            foreach (PodsistemProizvodnje p in proizvodnja)
            {
                if (p.PreostalaKolicina < 100)
                    return true;
            }
            return false;
        }
    }
}
