using Domain.Models;

namespace Domain.Repositories.PotrosaciRepositories
{
    public interface IPotrosaciRepository
    {
        public bool DodajPotrosaca(Potrosac p);

        public Potrosac PotrosacPoId(Guid id);

        public IEnumerable<Potrosac> SviPotrosaci();
    }
}
