using Domain.Models;
using Domain.Repositories.ProizvodnjaRepositories;
using Domain.Services;

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
