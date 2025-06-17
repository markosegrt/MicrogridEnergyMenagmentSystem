using Domain.Services;

namespace Presentation.Screens
{
    public static class PotrosnjaScreen
    {
        public static void Prikazi(Guid potrosacId, IPotrosnja potrosnji)
        {
            Console.Clear();
            Console.Write("Unesite količinu (kWh): ");
            double kolicina = double.Parse(Console.ReadLine() ?? "0");

            potrosnji.ZahtevajPotrosnju(potrosacId, kolicina);
            Console.WriteLine("Zahtev obrađen.");
            Console.ReadLine();
            MenuScreen.Prikazi(potrosacId, potrosnji);
        }
    }
}