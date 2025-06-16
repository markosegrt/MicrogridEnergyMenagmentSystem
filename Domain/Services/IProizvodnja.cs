using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Domain.Services
{
    public interface IProizvodnja
    {
        void DodajProizvodniSistem(PodsistemProizvodnje podsistemProizvodnje);
        double ObradiZahtev(double kolicina);


    }
}
