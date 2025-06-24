

using Domain.Services;

namespace Domain.Repositories.EvidencijaRepositories
{
    public class EvidencijaRepository:IEvidencijaRepository
    {
        private static readonly List<string> _evidencija = new();

        public EvidencijaRepository() { }

        public bool DodajEvidenciju(string evidencija)
        {
            if (string.IsNullOrEmpty(evidencija))
                return false;
            else
                _evidencija.Add(evidencija);
                return true;
        }

        public IEnumerable<string> VratiEvidenciju()
        {
            return _evidencija;
        }
    }
}
