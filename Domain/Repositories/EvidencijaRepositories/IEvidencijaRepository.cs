

namespace Domain.Repositories.EvidencijaRepositories
{
    public interface IEvidencijaRepository
    {

        public bool DodajEvidenciju(string evidencija);
        public IEnumerable<string> VratiEvidenciju();
    }
}
