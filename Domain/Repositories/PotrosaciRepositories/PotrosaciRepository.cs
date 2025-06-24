using Domain.Enums;
using Domain.Models;

namespace Domain.Repositories.PotrosaciRepositories
{
    public class PotrosaciRepository : IPotrosaciRepository
    {
        private static List<Potrosac> potrosaci;

        static PotrosaciRepository()
        {
            potrosaci = [
                new ("Milan Nikolić", "UG-001", Tip_Snabdevanja.KOMERCIJALNO, 0, 0),
                new ("Sinan Nikolić", "UG-002", Tip_Snabdevanja.GARANTOVANO, 0, 0),
                new ("Ana Nikolić", "UG-003", Tip_Snabdevanja.KOMERCIJALNO, 0, 0),
            ];
        }

        public bool DodajPotrosaca(Potrosac p)
        {
            foreach (var potrosac in potrosaci)
            {
                if (potrosac.BrPotrosackogUgovora == p.BrPotrosackogUgovora)
                    return false;
            }

            potrosaci.Add(p);
            return true;
        }

        public Potrosac PotrosacPoId(Guid id)
        {
            foreach (var p in potrosaci)
            {
                if (p.JedinstveniId == id)
                    return p;
            }

            return new();
        }

        public IEnumerable<Potrosac> SviPotrosaci()
        {
            return potrosaci;
        }
    }
}
