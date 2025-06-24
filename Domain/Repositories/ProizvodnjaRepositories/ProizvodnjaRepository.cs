using Domain.Models;
using Domain.Enums;

namespace Domain.Repositories.ProizvodnjaRepositories
{
    public class ProizvodnjaRepository : IProizvodnjaRepository
    {
        private static List<PodsistemProizvodnje> podsistemi = new();

        static ProizvodnjaRepository()
        {
            podsistemi = [
                new ("NS-001", Tip_Proizvodnje.ECOGREEN, "Novi Sad", 1000),
                new ("BG-002", Tip_Proizvodnje.CVRSTOGORIVO, "Beograd", 1500),
                new ("DJ-003", Tip_Proizvodnje.HIDROELEKTRANA, "Djerdap", 1400),
                ];
        }

        public bool DodajPodsistem(PodsistemProizvodnje sistem)
        {
            foreach (var p in podsistemi)
            {
                if (p.Sifra == sistem.Sifra)
                    return false; // već postoji
            }

            podsistemi.Add(sistem);
            return true;
        }

        public PodsistemProizvodnje PoSifri(string sifra)
        {
            foreach (var p in podsistemi)
            {
                if (p.Sifra == sifra)
                    return p;
            }

            return new PodsistemProizvodnje();//
        }

        public IEnumerable<PodsistemProizvodnje> Svi()
        {
            return podsistemi;
        }
    }
}
