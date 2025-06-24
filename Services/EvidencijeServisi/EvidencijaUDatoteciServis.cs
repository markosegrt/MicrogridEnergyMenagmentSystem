using Domain.Models;
using Domain.Services;

namespace Services.EvidencijeServisi
{
    public class EvidencijaUDatoteciServis : IEvidencijaServis
    {
        private const string Putanja = "C:\\Users\\Lenovo\\Desktop\\evidencija.txt";

        public bool Zapisi(double kolicina)
        {
            try
            {
                string vreme = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                string unos = $"{vreme}: Издато је {kolicina} kW.";
                File.AppendAllText(Putanja, unos + Environment.NewLine);
                Console.WriteLine($"[FAJL] {unos}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GREŠKA] Neuspešan upis u datoteku: {ex.Message}");
                return false;
            }
        }
    }
}
