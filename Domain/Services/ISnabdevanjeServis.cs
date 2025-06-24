namespace Domain.Services
{
    public interface ISnabdevanjeServis
    {
        public bool DopuniEnergiju();

        public bool IzdajEnergiju(double kolicina);
    }
}
