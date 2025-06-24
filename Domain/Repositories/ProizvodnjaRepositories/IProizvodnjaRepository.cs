using Domain.Models;

namespace Domain.Repositories.ProizvodnjaRepositories
{
    public interface IProizvodnjaRepository
    {
        bool DodajPodsistem(PodsistemProizvodnje sistem);
        PodsistemProizvodnje PoSifri(string sifra);
        IEnumerable<PodsistemProizvodnje> Svi();
    }
}
