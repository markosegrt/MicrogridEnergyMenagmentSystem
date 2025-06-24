using Domain.Repositories.PotrosaciRepositories;

namespace Presentation.Screens
{
    public static class PregledPotrosacaScreen
    {
        public static void Prikazi(IPotrosaciRepository repo)
        {
            Console.Clear();
            foreach (var p in repo.SviPotrosaci())
                Console.WriteLine($"{p.ImePrezime} | {p.BrPotrosackogUgovora} | {p.TipSnabdevanja}");
            Console.WriteLine("ENTER za povratak.");
            Console.ReadLine();
        }
    }
}
