using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Evidencije
{
    public class EvidencijaUDatoteci : IEvidencija
    {
        private const string Putanja = "evidencija.txt";

        public void Zapisi(Potrosac potrosac, double kolicina)
        {
            string unos = $"[{DateTime.Now}] {potrosac.ImePrezime} ({potrosac.JedinstveniId}) – {kolicina} kWh";
            File.AppendAllText(Putanja, unos + Environment.NewLine);
            Console.WriteLine($"[FAJL] {unos}");
        }
    }
}
