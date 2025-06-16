using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Services
{
    public interface ISnabdevanje
    {
        double CenaPoKWh { get; }
        double IzracunajRealnuKolicinu(double zahtevanaKolicina);
        string VratiTip(); //gar ili kom
    }
}
