using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Screens
{
    public static class AuthScreen
    {
        public static void Prikazi(IPotrosnja potrosnji, List<Potrosac> potrosaci)
        {
            Console.Clear();
            Console.WriteLine("Dobrodošli u ERS Mikro Mrežu!");
            Console.Write("Unesite broj ugovora:");
            var broj = Console.ReadLine();

            var korisnik = potrosaci.FirstOrDefault(p => p.BrPotrosackogUgovora == broj);
            if (korisnik != null)
            {
                Console.WriteLine($"Dobrodošli, {korisnik.ImePrezime}!");
                Thread.Sleep(500);
                MenuScreen.Prikazi(korisnik.JedinstveniId, potrosnji);
            }
            else
            {
                Console.WriteLine("Nepoznat ugovor. Pritisnite ENTER za ponovni pokušaj.");
                Console.ReadLine();
                Prikazi(potrosnji, potrosaci);
            }
        }
    }
}
