using Domain.Models;
using Domain.Services;
using Domain.Repositories.ProizvodnjaRepositories;

namespace Services.OdabirProizvodnjeServisi

{
    public class OdabirProizvodnjeServis : IOdabirProizvodnjeServis
    {
        private readonly IProizvodnjaRepository _repo;

        public OdabirProizvodnjeServis(IProizvodnjaRepository repo)
        {
            _repo = repo;
        }

        public PodsistemProizvodnje? OdaberiNajbolji()
        {
            return _repo.Svi()
                .OrderByDescending(s => s.PreostalaKolicina)
                .FirstOrDefault();
        }
    }
}
