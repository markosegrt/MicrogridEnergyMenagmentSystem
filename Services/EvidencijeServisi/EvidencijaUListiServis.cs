using Domain.Repositories.EvidencijaRepositories;
using Domain.Services;
using System.Text;

namespace Services.EvidencijeServisi
{
    public class EvidencijaUListiServis : IEvidencijaServis
    {
        private readonly IEvidencijaRepository evidencija = new EvidencijaRepository();

        public EvidencijaUListiServis() { }

        public EvidencijaUListiServis(IEvidencijaRepository evidencija)
        {
            this.evidencija = evidencija;
        }

        public bool Zapisi(double kolicina)
        {
            try
            {
                string vreme = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                string unos = $"{vreme}: Izdato je {kolicina} kW.";
                Console.WriteLine($"[LISTA] {unos}");
                evidencija.DodajEvidenciju(unos);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string VratiEvidenciju()
        {
            var evidencije = evidencija.VratiEvidenciju();
            StringBuilder izlaz = new StringBuilder();

            foreach (string e in evidencije)
            {
                izlaz.AppendLine(e);
            }
            return izlaz.ToString();

        }

    }
}
