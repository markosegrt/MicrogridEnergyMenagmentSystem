using Domain.Services;

namespace Presentation.Screens
{
    public static class ZaduzenjeScreen
    {
        public static void Prikazi(Guid potrosacId, IPotrosnja potrosnji)
        {
            // Koristimo novu metodu iz IPotrosnja da dobijemo zaduženje
            double zaduzenje = potrosnji.VratiZaduzenje(potrosacId);

            Console.Clear();
            Console.WriteLine($"Trenutno zaduženje: {zaduzenje} RSD");
            Console.ReadLine();
            MenuScreen.Prikazi(potrosacId, potrosnji);
        }
    }
}