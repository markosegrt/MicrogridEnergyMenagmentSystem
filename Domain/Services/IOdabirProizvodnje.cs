using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    public interface IOdabirProizvodnje
    {
        void DodajPodsistem(PodsistemProizvodnje sistem);
        
        PodsistemProizvodnje? OdaberiNajbolji(double potrebnaKolicina); //? znaci da moze da vrati null
    }
}
