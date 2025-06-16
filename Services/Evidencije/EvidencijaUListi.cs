using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;

namespace Services.Evidencije
{
    public class EvidencijaUListi:IEvidencija
    {
        private readonly List<string> _log = new();

        public void Zapisi(Potrosac potrosac, double kolicina)
        {
            string unos = $"[{DateTime.Now}] {potrosac.ImePrezime} ({potrosac.JedinstveniId}) – {kolicina} kWh";
            _log.Add(unos);
            Console.WriteLine($"[MEM] {unos}");
        }

        // Opcionalnalna metoda da procitas sve unose ( za testiranje)????????
        public List<string> VratiEvidenciju()
        {
            return _log;
        }
    }
}
