namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Radni direktorijum: " + System.IO.Directory.GetCurrentDirectory());
            Presentation.App.Run();
        }
    }
}