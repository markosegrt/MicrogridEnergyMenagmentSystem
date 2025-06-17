using Domain.Services;

namespace Presentation.Screens
{
    public static class MenuScreen
    {
        public static void Prikazi(Guid potrosacId, IPotrosnja potrosnji)
        {
            Console.Clear();
            Console.WriteLine("Glavni meni:");
            Console.WriteLine("1. Zahtevaj potrošnju");
            Console.WriteLine("2. Pregled zaduženja");
            Console.WriteLine("3. Izlaz");

            var izbor = Console.ReadLine();
            switch (izbor)
            {
                case "1":
                    PotrosnjaScreen.Prikazi(potrosacId, potrosnji);
                    break;
                case "2":
                    ZaduzenjeScreen.Prikazi(potrosacId, potrosnji);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}