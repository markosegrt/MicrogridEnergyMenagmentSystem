using Domain.Models;

namespace Domain.Services
{
    public interface IPotrosnjaServis
    {
        public bool ZahtevajPotrosnju(Guid potrosacId, double kolicina);
        public double VratiZaduzenje(Guid potrosacId);
    }
}
